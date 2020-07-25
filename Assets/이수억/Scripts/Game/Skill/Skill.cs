using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : Actor, IPoolObject
{
	public virtual void Activate(Vector3 pos)
	{
		position = pos;
	}

	public virtual void DeActivate()
	{

	}



	public void Recycle()
	{
		DeActivate();
		PoolMgr.In.Put( PoolMgr.POOL_SKILL, cGameObj );
	}
}
