using DG.Tweening;
using MoreMountains.Tools;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
	idle,
	attkck,
	move,
	die,
	hit,
	jump,
	dash,
}

public class MovementController : PlayerController
{
	public MMStateMachine<PlayerState> state;

	public Rigidbody2D rb;

	private float moveDir = 0f;

	private const float DOUBLE_CLICK_TIME = 1f;
	private float lastClickTime;
	
	float beforeDir;

	float dashCoolTime = .5f;
	float curDashDelay = 0f;
	bool isDashPossible => curDashDelay >= dashCoolTime;

	public override void Init( Character c )
	{
		base.Init( c );
		state = new MMStateMachine<PlayerState>( gameObject, false );
	}

	public override void Process()
	{
		base.Process();

		if ( c.stat.isDie )
			return;

		if ( state.CurrentState == PlayerState.attkck || state.CurrentState == PlayerState.die || state.CurrentState == PlayerState.hit || state.CurrentState == PlayerState.dash ) {
			return;
		}

		curDashDelay += Time.deltaTime;

		moveDir = Input.GetAxisRaw( "Horizontal" );
		if( moveDir == 0 ) {
			Transition( PlayerState.idle, false );
			return;
		}

		CheckFlip( moveDir );

		//Log.Check.I( $"[MoveDir] {moveDir}" );
		if ( isDashPossible && beforeDir == moveDir && state.CurrentState == PlayerState.idle ) {
			float timeSinceLastClick = Time.time - lastClickTime;
			if ( timeSinceLastClick <= DOUBLE_CLICK_TIME ) {
				// Double click!
				Transition( PlayerState.dash, true );
			} else {
				// Normal click!
				Transition( PlayerState.move, false );
			}
			lastClickTime = Time.time;
		} else {
			Transition( PlayerState.move, false );
		}
		beforeDir = moveDir;
	}


	void CheckFlip(float dir )
	{
		if ( dir >= 1f ) {
			c.render.Right();
		} else if ( dir <= -1f ) {
			c.render.Left();
		} else {
			
		}
	}


	void FixedUpdate()
	{
		if ( state.CurrentState == PlayerState.attkck || state.CurrentState == PlayerState.die || state.CurrentState == PlayerState.hit || state.CurrentState == PlayerState.dash) {
			return;
		}
		rb.MovePosition( rb.position + new Vector2( moveDir * Time.fixedDeltaTime * c.stat.movSpd, 0f ) );
	}

	//Coroutine endActionCo = null;

	public void Transition(PlayerState targetState, bool forceChange = false )
	{
		//Log.Check.I( $"[Transition] Try {targetState}" );

		if ( targetState == state.CurrentState && forceChange == false)
			return;

		switch ( targetState ) {
			case PlayerState.idle:
				c.render.PlayAnimation( targetState, true, null, 0.2f );
				break;
			case PlayerState.attkck:
				c.render.PlayAnimation( targetState, false, null, 0.2f );

				//if ( endActionCo != null ) StopCoroutine( endActionCo );
				//endActionCo = StartCoroutine( EndActionCo( 0.2f, OnAttackEnd ) );
				Invoke( "OnAttackEnd", 0.15f );

				break;
			case PlayerState.move:
				c.render.PlayAnimation( targetState, true, null, 0.2f );
				break;

			case PlayerState.die:
				c.render.PlayAnimation( targetState, false, null, 0.5f );

				//if ( endActionCo != null ) StopCoroutine( endActionCo );
				//endActionCo = StartCoroutine( EndActionCo( 0.2f, OnDieEnd ) );
				Invoke( "OnDieEnd", 0.5f );

				break;
			case PlayerState.hit:
				c.render.PlayAnimation( targetState, false, null, 0.5f );

				//if ( endActionCo != null ) StopCoroutine( endActionCo );
				//endActionCo = StartCoroutine( EndActionCo( 0.2f, OnHitEnd ) );
				Invoke( "OnHitEnd", 0.15f );

				break;
			case PlayerState.dash:
				c.render.PlayAnimation( targetState, true, null, 0.1f );

				float minX = -8f;
				float maxX = 8f;
				float target = 3f;
				Vector3 dashFxRot = Vector3.zero;
				if( moveDir == 1f ) {
					target = Mathf.Min( Mathf.Abs(maxX - c.position.x), target );
					dashFxRot = new Vector3( -180f, 90f, 180f );
				} else if( moveDir == -1f ) {
					target = Mathf.Min( Mathf.Abs( minX  - c.position.x), target );
					target *= -1f;
					dashFxRot = new Vector3( -180f, -90f, 180f );
				}
				Vector3 targetPos = c.position + new Vector3( target, 0, 0 );
				c.transform.DOMove( targetPos, 0.25f).SetEase( Ease.OutCubic ).OnComplete( () => {
					Transition( PlayerState.idle );
				} );
				curDashDelay = 0f;

				var fx = PoolFactory.In.GenerateFx( "DashFx", StageMan.In.con.holder.bulletHolder );
				fx.Activate( c.body.position + new Vector3( moveDir * 2f, -0.2f, 0 ) );
				fx.rotation = Quaternion.Euler( dashFxRot.x, dashFxRot.y, dashFxRot.z );


				break;
			default:
				break;
		}

		//Log.Check.I( $"[Transition] - Success {targetState}" );
		state.ChangeState( targetState );
	}

	//IEnumerator EndActionCo(float time, Action action)
	//{
	//	yield return new WaitForSeconds( time );
	//	action?.Invoke();
	//}

	//Coroutine dashCo = null;
	//IEnumerator DashSpdDownCo()
	//{
	//	dashSpeed = 50f;
	//	yield return new WaitForSeconds( 0.1f );
	//	dashSpeed = 1f;
	//	dashCo = null;
	//	Transition( PlayerState.idle );
	//	//while ( true ) {
	//	//	yield return null;
	//	//	dashSpeed -= Time.deltaTime * 20f;
	//	//	if( dashSpeed <= 1f ) {
	//	//		dashSpeed = 1f;
	//	//		dashCo = null;
	//	//		Transition( PlayerState.idle );
	//	//		yield break;
	//	//	}
	//	//}
	//}

	void OnHitEnd()
	{
		if ( !c.stat.isDie )
			Transition( PlayerState.idle, false );
	}

	void OnAttackEnd()
	{
		if( !c.stat.isDie )
			Transition( PlayerState.idle, false );
	}

	void OnDieEnd()
	{
		c.OnDie();
	}
}

