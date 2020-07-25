using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
	public class UIAbilityTest : MonoBehaviour
	{
		public GameObject pfAbility;
		public Transform holder;

		public void Init()
		{
			GenerateStates();
		}

		public void GenerateStates()
		{
			var abilites = System.Enum.GetValues( typeof( AbilityKind ) );
			foreach ( var item in abilites ) {
				AbilityKind abil = (AbilityKind)item;
				if ( abil == AbilityKind.None )
					continue;

				var obj = Instantiate( pfAbility, holder ).GetComponent<UIAbility>();
				obj.Init( abil, StageMan.In.player );
			}
		}
	}

}
