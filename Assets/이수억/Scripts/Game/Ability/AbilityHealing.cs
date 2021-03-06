﻿using DevelopeCommon;
using UnityEngine;

public class AbilityHealing : Ability
{
	public bool isOn = false;

	public void Activate()
	{
		if( isOn == false ) {
			InvokeRepeating( "Healing", 0f, Balance.HEALING_TERM );
			isOn = true;
		}
	}

	public void DeActivate()
	{
		isOn = false;
		CancelInvoke( "Healing" );
	}

	void Healing()
	{
		if ( c == null ) 
			return;

		c.stat.Heal( c.stat.healing );
		//Broadcaster.SendEvent( Constant.Event.RefreshUI, TypeOfMessage.dontRequireReceiver );
	}
}
