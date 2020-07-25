using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Projectile
{
	public class Bullet : Actor, IPoolObject
	{
		public struct Data
		{
			public Character character;
			public float damage;
			public float angleZ;
			public float speed;
		}
		public Data data;

		public void Init(Data data )
		{
			this.data = data;
		}

		public virtual void Activate( Vector3 pos )
		{
			position = pos;
			rotation = Quaternion.Euler( 0, 0, data.angleZ );
		}

		public virtual void DeActivate()
		{
			cTrf.rotation = Quaternion.identity;
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
