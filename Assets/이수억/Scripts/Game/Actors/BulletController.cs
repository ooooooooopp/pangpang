using Projectile;
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

	public override void Process()
	{
		base.Process();

		CheckFire();
	}

	void CheckFire()
	{
		if ( Input.GetKeyDown( KeyCode.Space ) ) 
		{
			Fire();
		}
	}

	void Fire()
	{
		if( c.abilityCon.HasAbility( AbilityKind.Double ) ) {
			curKind = BulletKind.DoubleChain;
		}

		if ( c.abilityCon.HasAbility( AbilityKind.Triple ) ) {
			Shoot( 0f );
			Shoot( 45f );
			Shoot( -45f );
		} else {
			Shoot( 0f );
		}
	}

	void Shoot(float angle)
	{
		if( curKind == BulletKind.Chain ) {
			GenBullet( angle, Vector3.zero );
		}
		else if( curKind == BulletKind.DoubleChain ) {
			GenBullet( angle, Vector3.left * 0.1f );
			GenBullet( angle, Vector3.right * 0.1f );
		}
	}

	Bullet GenBullet(float angle, Vector3 offset)
	{
		var bullet = PoolFactory.In.GenerateBullet( CHAIN, StageMan.In.con.holder.bulletHolder );
		bullet.Init( new Bullet.Data() { damage = c.stat.atk, character = c, angleZ = angle, speed = c.stat.bulletSpd } );
		bullet.Activate( c.position + offset );
		return bullet;
	}


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
