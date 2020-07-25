﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class RenderController : PlayerController
{
	public SpriteRenderer render;
	public SpriteLibScriptable spriteLib;

	Coroutine playCo = null;

	public override void Init( Character c )
	{
		base.Init( c );
		var set = spriteLib.GetSpriteSet( c.gender, PlayerState.idle );
		render.sprite = set.sprites[0];
	}

	public void PlayAnimation(PlayerState state, bool isLoop, Action onEnd = null, float term = 0.2f)
	{
		var set = spriteLib.GetSpriteSet( c.gender, state );

		if ( playCo != null ) {
			StopCoroutine( playCo );
		}

		if( isLoop ) {
			playCo = StartCoroutine( AnimationLoopCo( set.sprites, term ) );
		} else {
			playCo = StartCoroutine( AnimationCo( set.sprites, term, onEnd ) );
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

