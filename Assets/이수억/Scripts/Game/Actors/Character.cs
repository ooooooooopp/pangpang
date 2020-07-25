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

//�÷��̾� ���� ���������ΰ�.
//���ݷ� ���ݼӵ� ü�� �̵��ӵ�
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

	//�ǰݹ޾Ҵٸ� data �� ����ó���� �Ѵ�.	
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