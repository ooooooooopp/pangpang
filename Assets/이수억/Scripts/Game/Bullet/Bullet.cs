using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Projectile
{
	public class Bullet : Actor, IPoolObject
	{
		public struct Data
		{
			public float damage;
		}
		public Data data;

		public virtual void Activate( Vector3 pos )
		{
			position = pos;
		}

		public virtual void DeActivate()
		{

		}

		public virtual void Process()
		{

		}

		private void Update()
		{
			Process();
		}

		public virtual void Recycle()
		{
			DeActivate();
			PoolMgr.In.Put( PoolMgr.POOL_BULLET, cGameObj );
		}
	}

}
