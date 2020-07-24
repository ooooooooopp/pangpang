using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class StageMan : SingletonMonoD<StageMan>
{
	[HideInInspector]
	public StageConstructor con;

	public void Init( StageConstructor con )
	{
		this.con = con;
	}

	void Fin()
	{
		con.Fin();

		//GameMan.ChangeScene( GameScene.Lobby );
	}

}

