using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
	public class UIGameTest : MonoBehaviour
	{
		public GameObject pfStat;
		public Transform statHolder;

		public void Init()
		{
			GenerateStates();
		}

		public void GenerateStates()
		{
			var states = System.Enum.GetValues( typeof( StatKind ) );

			foreach ( var item in states ) {
				StatKind stat = (StatKind)item;
				var obj = Instantiate( pfStat, statHolder ).GetComponent<UIStat>();
				obj.Init( stat, StageMan.In.player );
			}
		}
	}

}
