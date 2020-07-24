using UnityEngine;
using UnityEngine.SceneManagement;

//플레이어 스탯 있을예정인것.
//공격력 공격속도 체력 이동속도

namespace Suoki
{
	public class Player : Actor
	{
		public float moveSpeed = 4f;
		private float moveDir = 0f;
		public Rigidbody2D rb;

		void Update()
		{
			moveDir = Input.GetAxisRaw( "Horizontal" );
			CheckFire();
		}

		void CheckFire()
		{
			if ( Input.GetKeyDown( KeyCode.Space ) ) {
				var bullet = PoolFactory.In.GenerateBullet( "Chain", StageMan.In.con.holder.bullets );
				bullet.Activate( position );
			}
		}

		void FixedUpdate()
		{
			rb.MovePosition( rb.position + new Vector2( moveDir * Time.fixedDeltaTime * moveSpeed, 0f ) );
		}

		void OnCollisionEnter2D( Collision2D col )
		{
			if ( col.collider.tag == "Ball" ) {
				PoolMgr.In.Destory();
				//Debug.Log( "GAME OVER!" );
				SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex );
			}
		}
	}
}
