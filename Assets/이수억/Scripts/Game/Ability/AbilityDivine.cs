using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityDivine : Ability
{
	public bool isOn = false;

	public void Activate()
	{
		if ( isOn == false ) {
			InvokeRepeating( "Divine", 0f, Balance.HEALING_TERM );
			isOn = true;
		}
	}

	public void DeActivate()
	{
		isOn = false;
		CancelInvoke( "Divine" );
	}

	void Divine()
	{
		if ( c == null )
			return;

		//c.stat.Heal( c.stat.healing );
		//Broadcaster.SendEvent( Constant.Event.RefreshUI, TypeOfMessage.dontRequireReceiver );
	}
}
