using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerDataMan : SingletonMonoD<PlayerDataMan>
{
	/// <summary>
	/// 스테이지가 바뀔때 씬전환으로 하면 구조 변경해야함.  D 로 되어있음.
	/// </summary>

	public struct PlayerData
	{
		public AbilityKind kinds;



	}

	public PlayerData data;

	//게임외부에서 데이터를 받아오는경우. ( 상점아이템, 장비 등 ) 주는거에따라 인자랑 세팅 변경할것.
	public void ImportData()
	{

	}

	//어빌리티를 얻은경우. 데이터 갱신할것.
	public void GetAbility()
	{

	}



}
