using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : PlayerController
{
	public Rigidbody2D rb;

	private float moveDir = 0f;

	public override void Process()
	{
		base.Process();
		moveDir = Input.GetAxisRaw( "Horizontal" );
	}

	void FixedUpdate()
	{
		rb.MovePosition( rb.position + new Vector2( moveDir * Time.fixedDeltaTime * c.stat.movSpd, 0f ) );
	}

}
