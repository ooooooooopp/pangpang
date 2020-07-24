using UnityEngine;

namespace Projectile
{
	public class BulletBody : MonoBehaviour
	{
		public Bullet bullet;

		void OnTriggerEnter2D( Collider2D col )
		{
			if ( col.tag == TagName.BALL ) {
				col.GetComponent<Ball>().Split();
			}
			bullet.Recycle();
		}
	}
}
