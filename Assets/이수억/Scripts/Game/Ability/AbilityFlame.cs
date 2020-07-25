using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityFlame : Ability
{
	Coroutine co = null;
	public float flameTerm => c.moveCon.state.CurrentState == PlayerState.move ? 0.25f : 1f;

	public void Activate()
	{
		if ( co != null ) StopCoroutine( co );
		co = StartCoroutine( FlameGenCo() );
	}

	public void DeActivate()
	{
		if ( co != null ) 
			StopCoroutine( co );
	}

	IEnumerator FlameGenCo()
	{
		while ( true ) {
			yield return new WaitForSeconds( flameTerm );
			GenFlame();
		}
	}

	Flame GenFlame( )
	{
		var flame = PoolFactory.In.GenerateSkill( "Flame", StageMan.In.con.holder.bulletHolder ).GetComponent<Flame>();
		flame.Init( c );
		flame.Activate( c.foot.position + Vector3.up * 0.1f );
		return flame;
	}
}
