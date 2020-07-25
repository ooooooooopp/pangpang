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
		c.stat.hp -= data.damage;
		Broadcaster.SendEvent( Constant.Event.RefreshUI, TypeOfMessage.dontRequireReceiver );
		if ( c.stat.hp <= 0 ) {
			StageMan.In.GameOver();
			return true;
		}
		return false;
	}

}
