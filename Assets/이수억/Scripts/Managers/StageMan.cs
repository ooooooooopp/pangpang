using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 
/// </summary>
public class StageMan : SingletonMonoD<StageMan>
{
	[HideInInspector]
	public StageConstructor con;
	public UIGameTest ui;

	Coroutine startCo = null;

	public GameObject pfPlayer;
	[HideInInspector]
	public Character player = null;

	public void Init( StageConstructor con )
	{
		this.con = con;

		if ( startCo != null ) startCo = null;
		startCo = StartCoroutine( StartGameCo() );

		ui.Init();
	}

	void Fin()
	{
		player.Fin();
		Destroy( player.gameObject );

		con.Fin();
		PoolMgr.In.Destory();
	}

	IEnumerator StartGameCo()
	{
		GeneratePlayer();
		GenerateBall();

		yield return null;
	}

	public void MonsterDie()
	{
		//monster death count 체크.
	}

	public void GeneratePlayer()
	{
		player = Instantiate( pfPlayer, con.holder.playerHolder ).GetComponent<Character>();
		player.position = con.holder.playerSpawnHolder.position;
		player.Init();
	}

	public void GenerateBall()
	{
		SBall.Gen( "Ball_5", con.holder.monsterSpawnHolder.position, new Vector2( 2f, 0f ) );
	}



	public void GameOver()
	{
		Fin();
		SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex );
	}
}

