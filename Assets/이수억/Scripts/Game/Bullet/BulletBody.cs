using UnityEngine;

namespace Projectile
{
	public class BulletBody : MonoBehaviour
	{
		public Bullet bullet;

		void OnTriggerEnter2D( Collider2D col )
		{
			if ( col.tag == TagName.BALL ) {
				col.GetComponent<IDamagable>().TakeDamage(new DamagableData() {
					attacker = bullet.cGameObj,
					damage = bullet.data.damage,
				} );
			}
			bullet.Recycle();
		}
	}
}
