using UnityEngine;

public class SBall : Actor, IPoolObject, IDamagable
{
	public float scale;
	public Vector2 startForce;

	public GameObject nextBall;

	public Rigidbody2D rb;

	public void Activate(Vector3 pos)
	{
		cTrf.localScale = Vector3.one * scale;
		position = pos;
		rb.AddForce( startForce, ForceMode2D.Impulse );
	}

	public void DeActivate()
	{

	}

	public void Recycle()
	{
		DeActivate();
		PoolMgr.In.Put( PoolMgr.POOL_MONSTER, cGameObj );
	}

	public void Split()
	{
		if ( nextBall != null ) {

			Gen( nextBall.name, rb.position + Vector2.right / 4f, new Vector2( 2f, 5f ) );
			Gen( nextBall.name, rb.position + Vector2.left / 4f, new Vector2( -2f, 5f ) );

		} else {
			StageMan.In.MonsterDie();
		}

		Destroy( gameObject );
	}



	public bool TakeDamage( DamagableData data )
	{
		//데미지량이 넘어서면 리사이클로 나중에 변경.
		Recycle();

		if ( nextBall != null ) {
			Gen( nextBall.name, rb.position + Vector2.right / 4f, new Vector2( 2f, 5f ) );
			Gen( nextBall.name, rb.position + Vector2.left / 4f, new Vector2( -2f, 5f ) );
			return false;
		} else {
			StageMan.In.MonsterDie();
		}
		return true;
	}


	public static SBall Gen( string ballPrefabName, Vector3 pos, Vector3 startForce )
	{
		var obj = PoolFactory.In.GenerateBall( ballPrefabName, StageMan.In.con.holder.monsterHolder );
		obj.rotation = Quaternion.identity;
		var ball = obj.GetComponent<SBall>();
		ball.startForce = startForce;
		ball.Activate( pos );

		//StageMan. Add Managable Monster. Count ++ 

		return ball;
	}
}
