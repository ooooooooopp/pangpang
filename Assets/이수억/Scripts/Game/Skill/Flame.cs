using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : Skill
{
	Character c;
	public void Init(Character c)
	{
		this.c = c;
	}

	public override void Activate( Vector3 pos )
	{
		base.Activate( pos );
		Invoke( "Recycle", 3f );
	}

	public override void DeActivate()
	{
		base.DeActivate();
	}

	public void OnTriggerEnter2D( Collider2D col )
	{
		if ( col.tag == TagName.BALL ) {
			var dmgable = col.GetComponent<IDamagable>();
			if ( dmgable == null ) 
				return;

			dmgable.TakeDamage( new DamagableData() {
				attacker = cGameObj,
				damage = c.stat.atk,
			} );
		} 
	}
}
