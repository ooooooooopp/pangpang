using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudController : PlayerController
{
	public Image hpBar;
	public Image bulletBar;

	public override void Process()
	{
		base.Process();

		Debug.Log("체력" + c.stat.maxHp);
		hpBar.fillAmount = c.stat.hp / c.stat.maxHp;
		bulletBar.fillAmount = c.stat.bulletCount / (float)c.stat.maxBulletCount;
	}
}
