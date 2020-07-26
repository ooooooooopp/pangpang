using UnityEngine;

namespace Projectile
{
	public class BulletBody : MonoBehaviour
	{
		public Bullet bullet;

		void OnTriggerEnter2D( Collider2D col )
		{
			if ( col.tag == TagName.BALL ) {
				var dmgable = col.GetComponent<IDamagable>();
				if ( dmgable == null )
					return;

				var monster = col.GetComponent<MonsterHp>();
				if ( monster == null )
					return;

				if ( monster.currHp <= 0f )
					return;

				dmgable.TakeDamage( new DamagableData() {
					attacker = bullet.cGameObj,
					damage = bullet.data.damage,
				} );

				var fx = PoolFactory.In.GenerateFx( "BurstFx", StageMan.In.con.holder.bulletHolder );
				fx.Activate( col.transform.position );
				AudioController.Play( "BulletHit" );

				if ( bullet.data.isPenetrate == false ) {
					bullet.Recycle();
				}
			} else if ( col.tag == TagName.WALL ) {
				var fx = PoolFactory.In.GenerateFx( "BurstFx", StageMan.In.con.holder.bulletHolder );
				fx.Activate( bullet.position );
				bullet.Recycle();
				AudioController.Play( "BulletHit" );
			}
		}
	}
}

