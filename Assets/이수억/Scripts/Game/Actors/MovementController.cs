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
}

public class MovementController : PlayerController
{
	MMStateMachine<PlayerState> state;

	public Rigidbody2D rb;

	private float moveDir = 0f;
	float beforeInput = 0f;

	//float noInputTerm = 0f;

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

		if ( state.CurrentState == PlayerState.attkck || state.CurrentState == PlayerState.die || state.CurrentState == PlayerState.hit ) {
			return;
		}

		moveDir = Input.GetAxisRaw( "Horizontal" );


		if ( moveDir >= 1f ) {
			c.render.Right();
			Transition( PlayerState.move, false );
		}
		else if( moveDir <= -1f ){
			c.render.Left();
			Transition( PlayerState.move, false );
		} else {
			Transition( PlayerState.idle, false );
		}

		beforeInput = moveDir;

		//Log.Check.I( $"[MoveDir] {moveDir}" );
	}

	void FixedUpdate()
	{
		if ( state.CurrentState == PlayerState.attkck || state.CurrentState == PlayerState.die || state.CurrentState == PlayerState.hit ) {
			return;
		}

		rb.MovePosition( rb.position + new Vector2( moveDir * Time.fixedDeltaTime * c.stat.movSpd, 0f ) );
	}

	Coroutine endActionCo = null;

	public void Transition(PlayerState targetState, bool forceChange = false )
	{
		Log.Check.I( $"[Transition] Try {targetState}" );

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
			default:
				break;
		}

		Log.Check.I( $"[Transition] - Success {targetState}" );
		state.ChangeState( targetState );
	}

	IEnumerator EndActionCo(float time, Action action)
	{
		yield return new WaitForSeconds( time );
		action?.Invoke();
	}

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
