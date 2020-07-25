using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityDivine : Ability
{
	public SpriteRenderer divineRender;

	public bool isOn = false;
	
	float randTime => UnityEngine.Random.Range( Balance.DIVINE_TERM_MIN, Balance.DIVINE_TERM_MAX );
	private void Awake()
	{
		divineRender.enabled = false;
	}

	public void Activate()
	{
		if ( isOn == false ) {
			ReserveDivine();
			isOn = true;
		}
	}

	public void DeActivate()
	{
		isOn = false;
		CancelInvoke( "Divine" );
		CancelInvoke( "DivineOff" );
	}

	void ReserveDivine()
	{
		if ( c == null )
			return;
		Invoke( "Divine", randTime );
	}

	void ReserveDivineOff()
	{
		if ( c == null )
			return;

		Invoke( "DivineOff", c.stat.divTime );
	}

	void Divine()
	{
		if ( c == null )
			return;

		divineRender.enabled = true;
		c.ToggleDivine( true );
		ReserveDivineOff();
	}

	void DivineOff()
	{
		if ( c == null )
			return;

		divineRender.enabled = false;
		c.ToggleDivine( false );
	}
}
