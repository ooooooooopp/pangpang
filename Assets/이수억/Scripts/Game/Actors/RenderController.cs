using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class RenderController : PlayerController
{
	public SpriteRenderer render;
	//public SpriteLibScriptable spriteLib;
	
	public Sprite[] man_attack;
	public Sprite[] man_die;
	public Sprite[] man_hit;
	public Sprite[] man_idle;
	public Sprite[] man_move;

	public Sprite[] woman_attack;
	public Sprite[] woman_die;
	public Sprite[] woman_hit;
	public Sprite[] woman_idle;
	public Sprite[] woman_move;


	Coroutine playCo = null;

	public Sprite[] GetSprite(CharKind gender, PlayerState state)
	{
		switch ( gender ) {
			case CharKind.man:
				switch ( state ) {
					case PlayerState.idle:
						return man_idle;
					case PlayerState.attkck:
						return man_attack;
					case PlayerState.move:
						return man_move;
					case PlayerState.die:
						return man_die;
					case PlayerState.hit:
						return man_hit;
					case PlayerState.jump:
						return man_move;
					case PlayerState.dash:
						return man_move;
					default:
						break;
				}


				break;
			case CharKind.woman:
				switch ( state ) {
					case PlayerState.idle:
						return woman_idle;
					case PlayerState.attkck:
						return woman_attack;
					case PlayerState.move:
						return woman_move;
					case PlayerState.die:
						return woman_die;
					case PlayerState.hit:
						return woman_hit;
					case PlayerState.jump:
						return woman_move;
					case PlayerState.dash:
						return woman_move;
					default:
						break;
				}
				break;
			default:
				break;
		}
		return null;
	}

	public override void Init( Character c )
	{
		base.Init( c );
		var sprites = GetSprite( c.gender, PlayerState.idle );
		//var set = spriteLib.GetSpriteSet( c.gender, PlayerState.idle );
		render.sprite = sprites[0];
	}

	private void Start()
	{
		if( c != null ) {
			var sprites = GetSprite( c.gender, PlayerState.idle );
			render.sprite = sprites[0];
		}
	}

	public void PlayAnimation(PlayerState state, bool isLoop, Action onEnd = null, float term = 0.2f)
	{
		var set = GetSprite( c.gender, state );

		if ( playCo != null ) {
			StopCoroutine( playCo );
		}

		if( isLoop ) {
			playCo = StartCoroutine( AnimationLoopCo( set, term ) );
		} else {
			playCo = StartCoroutine( AnimationCo( set, term, onEnd ) );
		}
	}

	//애니메이션이 종료가 안되었는데 stop 하면 ONComplete를 호출못함.

	IEnumerator AnimationCo( Sprite[] sprites, float term, Action onEnd)
	{
		WaitForSeconds sec = new WaitForSeconds( term );
		int index = 0;
		while ( true ) {
			render.sprite = sprites[index++];
			if ( index >= sprites.Length ) {
				onEnd?.Invoke();
				playCo = null;
				yield break;
			}
			yield return sec;
		}
	}

	IEnumerator AnimationLoopCo( Sprite[] sprites, float term )
	{
		WaitForSeconds sec = new WaitForSeconds( term );
		int index = 0;
		while ( true ) {
			render.sprite = sprites[index++];
			if ( index >= sprites.Length ) {
				index = 0;
			}
			yield return sec;
		}
	}

	public void Left()
	{
		render.flipX = true;
	}

	public void Right()
	{
		render.flipX = false;
	}


}

