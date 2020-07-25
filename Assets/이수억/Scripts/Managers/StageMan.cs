using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
		PoolMgr.In.Destory();
		//GameMan.ChangeScene( GameScene.Lobby );
	}

	public void GameOver()
	{
		Fin();
		SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex );
	}
}

