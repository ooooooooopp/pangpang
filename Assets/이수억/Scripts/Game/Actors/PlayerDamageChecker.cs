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

	public bool TakeDamage( DamagableData data )
	{
		if( c.stat.isDivine ) {
			Log.to.I( "무적으로 피해안입음" );
			return false;
		}

		c.stat.hp -= data.damage;
		Broadcaster.SendEvent( Constant.Event.RefreshUI, TypeOfMessage.dontRequireReceiver );
		if ( c.stat.hp <= 0 ) {
			c.OnDie();
			//StageMan.In.GameOver();
			return true;
		}
		return false;
	}

}
