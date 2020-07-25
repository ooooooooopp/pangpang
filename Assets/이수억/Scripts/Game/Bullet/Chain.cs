using UnityEngine;

namespace Projectile
{
	public class Chain : Bullet
	{
		public override void Activate( Vector3 pos )
		{
			base.Activate( pos );
			cTrf.localScale = new Vector3( 1f, 0f, 1f );
		}

		public override void DeActivate()
		{
			base.DeActivate();
			cTrf.localScale = new Vector3( 1f, 0f, 1f );
		}

		public override void Process()
		{
			cTrf.localScale = cTrf.localScale + Vector3.up * Time.deltaTime * data.speed;
		}
	}
}
