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

	//private void Update()
	//{
	//	if( Input.GetKeyDown(KeyCode.I ) ) {
	//		TakeDamage( new DamagableData() {
	//			damage = 1000000,
	//			attacker = c.gameObject
	//		} );

	//		Log.to.I( "Cheat" );
	//	}
	//}

	public bool TakeDamage( DamagableData data )
	{
		if( c.stat.isDivine ) {
			Log.to.I( "무적으로 피해안입음" );
			return false;
		}

		if ( c.stat.isDie )
			return false;

		AudioController.Play( "PlayerHit" );

		c.stat.hp -= data.damage;
		if ( c.stat.hp <= 0 ) {
			AudioController.Play( "PlayerDie" );
			c.moveCon.Transition( PlayerState.die, true );
			//StageMan.In.GameOver();
			return true;
		} else {

			c.moveCon.Transition( PlayerState.hit, false );
		}
		return false;
	}

}
