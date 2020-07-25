using System;
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
			public bool isPenetrate;
		}
		public Data data;

		Action<Bullet> onRecycle = null;

		public void Init(Data data, Action<Bullet> onRecycle )
		{
			this.data = data;
			this.onRecycle = onRecycle;
		}

		public virtual void Activate( Vector3 pos )
		{
			position = pos;
			rotation = Quaternion.Euler( 0, 0, data.angleZ );
		}

		public virtual void DeActivate()
		{
			onRecycle = null;
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
			//리사이클 두번 방지.
			if( onRecycle == null ) {
				return;
			}

			onRecycle?.Invoke(this);
			DeActivate();
			PoolMgr.In.Put( PoolMgr.POOL_BULLET, cGameObj );
		}
	}

}
