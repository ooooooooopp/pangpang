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

	public void Init()
	{
		stat = new PlayerStat();
		stat.Init();

		abilityCon.Init(this);
		bulletCon.Init(this);
		moveCon.Init( this );
	}

	public void Fin()
	{
		abilityCon.Fin();
		bulletCon.Fin();
		moveCon.Fin();
	}

	void Update()
	{
		abilityCon.Process();
		bulletCon.Process();
		moveCon.Process();
	}


	void OnCollisionEnter2D( Collision2D col )
	{
		if ( col.collider.tag == TagName.BALL ) {
			StageMan.In.GameOver();
		}
	}

	public bool TakeDamage( DamagableData data )
	{
		stat.hp -= data.damage;
		//if( stat.hp <= 0 ) {
		//	StageMan.In.GameOver();
		//}


		return true;
	}
}
