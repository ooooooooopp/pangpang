using UnityEngine;

namespace Projectile
{
	public class Chain : Bullet
	{
		public float speed = 2f;
		bool isFired = false;

		//public struct Data
		//{
		//	public float speed;
		//}
		//public void Init( Data data )
		//{
		//}

		public override void Activate( Vector3 pos )
		{
			base.Activate( pos );
			cTrf.localScale = new Vector3( 1f, 0f, 1f );
			isFired = true;
		}

		public override void DeActivate()
		{
			base.DeActivate();
			cTrf.localScale = new Vector3( 1f, 0f, 1f );
			isFired = false;
		}

		public override void Process()
		{
			if ( isFired ) {
				cTrf.localScale = cTrf.localScale + Vector3.up * Time.deltaTime * speed;
			} else {
				cTrf.localScale = new Vector3( 1f, 0f, 1f );
			}
		}
	}

}
