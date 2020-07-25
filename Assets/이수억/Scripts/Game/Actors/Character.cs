using DevelopeCommon;
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
public class Character : Actor, IDamagable
{
	public PlayerStat stat;
	public AbilityController abilityCon;
	public BulletController bulletCon;
	public MovementController moveCon;

	public HudController hud;

	public void Init()
	{
		stat = new PlayerStat();
		stat.Init();

		abilityCon.Init(this);
		bulletCon.Init(this);
		moveCon.Init( this );
		hud.Init( this );
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

	//피격받았다면 data 에 의한처리를 한다.	
	public bool TakeDamage( DamagableData data )
	{
		stat.hp -= data.damage;
		Broadcaster.SendEvent( Constant.Event.RefreshUI, TypeOfMessage.dontRequireReceiver );
		if( stat.hp <= 0 ) {
			StageMan.In.GameOver();
			return true;
		}
		return false;
	}
}