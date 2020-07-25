using MoreMountains.Tools;
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

	public override void Init( Character c )
	{
		base.Init( c );
		state = new MMStateMachine<PlayerState>( gameObject, false );
	}

	public override void Process()
	{
		base.Process();

		if ( state.CurrentState == PlayerState.attkck || state.CurrentState == PlayerState.die || state.CurrentState == PlayerState.hit ) {
			return;
		}

		moveDir = Input.GetAxisRaw( "Horizontal" );

		if( moveDir >= 1f ) {
			c.render.Right();
			Transition( PlayerState.move, false );
		}
		else if( moveDir <= -1f ){
			c.render.Left();
			Transition( PlayerState.move, false );
		} else {
			Transition( PlayerState.idle, false );
		}

		Log.Check.I( $"[MoveDir] {moveDir}" );
	}

	void FixedUpdate()
	{
		rb.MovePosition( rb.position + new Vector2( moveDir * Time.fixedDeltaTime * c.stat.movSpd, 0f ) );
	}


	public void Transition(PlayerState targetState, bool forceChange = false )
	{
		if ( targetState == state.CurrentState && forceChange == false)
			return;

		switch ( targetState ) {
			case PlayerState.idle:
				c.render.PlayAnimation( targetState, true );
				break;
			case PlayerState.attkck:
				c.render.PlayAnimation( targetState, false, OnAttackEnd );
				break;
			case PlayerState.move:
				c.render.PlayAnimation( targetState, true );
				break;
			case PlayerState.die:
				c.render.PlayAnimation( targetState, false, OnDieEnd );
				break;
			case PlayerState.hit:
				c.render.PlayAnimation( targetState, false, OnHitEnd );
				break;
			default:
				break;
		}

		state.ChangeState( targetState );
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
