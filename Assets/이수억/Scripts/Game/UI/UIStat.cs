using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevelopeCommon;
using UnityEngine.UI;

namespace UI
{
	public class UIStat : MonoBehaviour
	{
		public Text txtLabel;
		public Text value;

		public StatKind kind;
		Character c;

		public void Init( StatKind kind, Character c )
		{
			this.kind = kind;
			this.c = c;

			Refresh();
		}

		private void Update()
		{
			Refresh();
		}

		void Refresh()
		{
			txtLabel.text = kind.ToString();

			switch ( kind ) {
				case StatKind.atk:
					value.text = c.stat.atk.ToString();
					break;
				case StatKind.hp:
					value.text = c.stat.hp.ToString();
					break;
				case StatKind.maxHp:
					value.text = c.stat.maxHp.ToString();
					break;
				case StatKind.movSpd:
					value.text = c.stat.movSpd.ToString();
					break;
				case StatKind.bulletSpd:
					value.text = c.stat.bulletSpd.ToString();
					break;
				case StatKind.bulletCount:
					value.text = c.stat.bulletCount.ToString();
					break;
				case StatKind.maxBulletCount:
					value.text = c.stat.maxBulletCount.ToString();
					break;
				case StatKind.divTime:
					value.text = c.stat.divTime.ToString();
					break;
				case StatKind.stopTime:
					value.text = c.stat.stopTime.ToString();
					break;
				case StatKind.jumpPower:
					value.text = c.stat.jumpPower.ToString();
					break;
				case StatKind.healing:
					value.text = c.stat.healing.ToString();
					break;
				default:
					break;
			}

		}
	}

}
