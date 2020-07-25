using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : Actor
{
	public float speed = 100f;
	Character c;

	bool isCol => curDelay >= delay;
	public float delay = 1f;
	float curDelay = 0f;

	public void Activate(Vector3 pos, Character c)
	{
		localPosition = pos;
		this.c = c;
	}

	public void FixedUpdate()
	{
		transform.RotateAround( c.cTrf.position, new Vector3( 0, 0, 1 ), speed * Time.fixedDeltaTime );
		curDelay += Time.fixedDeltaTime;
	}

	void OnTriggerEnter2D( Collider2D col )
	{
		if ( !isCol )
			return;

		if ( col.tag == TagName.BALL ) {
			col.GetComponent<IDamagable>().TakeDamage( new DamagableData() {
				attacker = cGameObj,
				damage = c.stat.atk,
			} );
			curDelay = 0f;
		}
	}
}