using DevelopeCommon;
using System;
using UnityEngine;

public abstract class PlayerController : MonoBehaviour
{
	[HideInInspector]
	public Character c;

	public virtual void Init(Character c )
	{
		this.c = c;
	}

	public virtual void Fin()
	{

	}

	public virtual void Process()
	{

	}
}

//플레이어 스탯 있을예정인것.
//공격력 공격속도 체력 이동속도
public class Character : Actor
{
	public PlayerStat stat;
	public AbilityController abilityCon;
	public BulletController bulletCon;
	public MovementController moveCon;

	public PlayerDamageChecker dmgChecker;

	public HudController hud;

	private void Awake()
	{
		Init();
	}

	public void Init()
	{
		stat = new PlayerStat();

		stat.Init(this);
		abilityCon.Init(this);
		bulletCon.Init(this);
		moveCon.Init( this );
		hud.Init( this );
		dmgChecker.Init( this );
	}


	public void Fin()
	{
		abilityCon.Fin();
		bulletCon.Fin();
		moveCon.Fin();
		hud.Fin();
	}

	void Update()
	{
		abilityCon.Process();
		bulletCon.Process();
		moveCon.Process();
		hud.Process();
	}


	public void ToggleDivine( bool isOn )
	{
		stat.isDivine = true;

	}

}
