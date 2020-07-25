using DevelopeCommon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageChecker : MonoBehaviour, IDamagable
{
	public Character c;

	public void Init(Character c )
	{
		this.c = c;
	}

	public void Fin()
	{

	}

	public bool TakeDamage( DamagableData data )
	{
		if( c.stat.isDivine ) {
			Log.to.I( "무적으로 피해안입음" );
			return false;
		}

		if ( c.stat.isDie )
			return false;

		c.stat.hp -= data.damage;
		if ( c.stat.hp <= 0 ) {
			c.moveCon.Transition( PlayerState.die, true );
			//StageMan.In.GameOver();
			return true;
		} else {
			c.moveCon.Transition( PlayerState.hit, false );
		}
		return false;
	}

}
