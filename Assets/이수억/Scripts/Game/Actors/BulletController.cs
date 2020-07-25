using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : PlayerController
{

	public override void Process()
	{
		base.Process();
		CheckFire();
	}

	void CheckFire()
	{
		if ( Input.GetKeyDown( KeyCode.Space ) ) {
			var bullet = PoolFactory.In.GenerateBullet( "Chain", StageMan.In.con.holder.bullets );
			bullet.Activate( c.position );
		}
	}


}
