using Projectile;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : PlayerController
{
	const string CHAIN = "Chain";

	public enum BulletKind
	{
		Chain,
		DoubleChain,
	}
	BulletKind curKind = BulletKind.Chain;

	//Shot 안에 총알들이 들어있고
	//샷에 들어간 총알 모두가 소진되어야 샷이 소진되는것으로.
	public class Shot
	{
		public Action<Shot> onClear;
		public List<Bullet> bullets;

		public Shot(Action<Shot> onClear )
		{
			this.onClear = onClear;
			bullets = new List<Bullet>();
		}

		public void OnRecycleBullet( Bullet bullet )
		{
 			if( bullets.Contains(bullet) ) {
				bullets.Remove( bullet );
			}
			if( bullets.Count <= 0 ) {
				onClear?.Invoke(this);
				onClear = null;
			}
		}
	}
	public List<Shot> shots = new List<Shot>();

	public override void Init( Character c )
	{
		base.Init( c );

		shots.Clear();
	}

	public override void Fin()
	{
		if ( fireCo != null )
			StopCoroutine( fireCo );
		base.Fin();
	}

	public override void Process()
	{
		base.Process();

		CheckFire();

		//Print();
	}

	void Print()
	{
		Log.to.I( $"[Shots] - Shot {shots.Count}" );
		foreach ( var item in shots ) {
			Log.to.I( $"[Shots] - Bullet {item.bullets.Count}" );
		}
	}

	void CheckFire()
	{
		if ( Input.GetKeyDown( KeyCode.Space ) ) {
			Fire();
		}
	}

	void Fire()
	{
		if ( shots.Count >= c.stat.maxBulletCount )
			return;

		//if ( fireCo != null ) StopCoroutine( fireCo );
		//fireCo = StartCoroutine( FireCo() );

		c.moveCon.Transition( PlayerState.attkck, true );

		if ( c.abilityCon.HasAbility( AbilityKind.Double ) ) {
			curKind = BulletKind.DoubleChain;
		}

		Shot shot = new Shot( OnClearShot );
		if ( c.abilityCon.HasAbility( AbilityKind.Triple ) ) {
			Shoot( 0f, shot );
			Shoot( 45f, shot );
			Shoot( -45f, shot );
		} else {
			Shoot( 0f, shot );
		}
		shots.Add( shot );

	}

	Coroutine fireCo = null;
	IEnumerator FireCo()
	{
		yield return new WaitForSeconds( 0.1f );
		c.moveCon.Transition( PlayerState.attkck, true );


		if ( c.abilityCon.HasAbility( AbilityKind.Double ) ) {
			curKind = BulletKind.DoubleChain;
		}

		Shot shot = new Shot( OnClearShot );
		if ( c.abilityCon.HasAbility( AbilityKind.Triple ) ) {
			Shoot( 0f, shot );
			Shoot( 45f, shot );
			Shoot( -45f, shot );
		} else {
			Shoot( 0f, shot );
		}
		shots.Add( shot );
	}

	void Shoot( float angle, Shot shot )
	{
		if ( curKind == BulletKind.Chain ) {
			shot.bullets.Add( GenBullet( angle, Vector3.zero, shot.OnRecycleBullet ) );
		} else if ( curKind == BulletKind.DoubleChain ) {
			shot.bullets.Add( GenBullet( angle, Vector3.left * 0.1f, shot.OnRecycleBullet ) );
			shot.bullets.Add( GenBullet( angle, Vector3.right * 0.1f, shot.OnRecycleBullet ) );
		}
	}

	Bullet GenBullet( float angle, Vector3 offset, Action<Bullet> onRecycle )
	{
		var bullet = PoolFactory.In.GenerateBullet( CHAIN, StageMan.In.con.holder.bulletHolder );
		bullet.Init( new Bullet.Data() 
		{ 
			damage = c.stat.atk, 
			character = c, 
			angleZ = angle, 
			speed = c.stat.bulletSpd,
			isPenetrate = c.abilityCon.HasAbility(AbilityKind.Penetrate),
		}, onRecycle );
		bullet.Activate( c.foot.position + offset );
		return bullet;
	}

	void OnClearShot(Shot shot )
	{
		if( shots.Contains( shot ) ) {
			shots.Remove( shot );
		}
	}

	//더블샷이랑
	//탄환 개수 개념이 겹침.
	//더블샷은 두개가 모두 사라져야 탄환이 재장전이 된다고 해야하나?




}


public static class ComplexEx
{
	public static Vector2 ComplexMult( this Vector2 aVec, Vector2 aOther )
	{
		return new Vector2( aVec.x * aOther.x - aVec.y * aOther.y, aVec.x * aOther.y + aVec.y * aOther.x );
	}
	public static Vector2 Rotation( float aDegree )
	{
		float a = aDegree * Mathf.Deg2Rad;
		return new Vector2( Mathf.Cos( a ), Mathf.Sin( a ) );
	}
	public static Vector2 Rotate( this Vector2 aVec, float aDegree )
	{
		return ComplexMult( aVec, Rotation( aDegree ) );
	}
}
