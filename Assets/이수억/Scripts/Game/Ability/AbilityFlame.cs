using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityFlame : Ability
{
	Coroutine co = null;
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
		WaitForSeconds sec = new WaitForSeconds( 0.5f );
		while ( true ) {
			yield return sec;
			GenFlame();
		}
	}

	Flame GenFlame( )
	{
		var flame = PoolFactory.In.GenerateSkill( "Flame", StageMan.In.con.holder.bulletHolder ).GetComponent<Flame>();
		flame.Init( c );
		flame.Activate( c.foot.position );
		return flame;
	}
}
