using UnityEngine;

public enum AbilityKind
{
	None				= 0,

	Double				= 1 << 1,			// 위로 두개가 쌍으로 나감.			Data
	Triple				= 1 << 2,			// 3갈래 탄이됨						Data

	BulletBonus_1		= 1 << 3,			// 장탄수 증가.						Data
	BulletBonus_2		= 1 << 4,			// 장탄수 증가.						Data
	BulletBonus_3		= 1 << 5,			// 장탄수 증가.						Data

	Divine				= 1 << 6,			// 랜덤하게 무적됨					Data
	
	BulletSpdUp_1		= 1 << 7,			// 총알 속도 증가.					Data
	BulletSpdUp_2		= 1 << 8,			// 총알 속도 증가.					Data
	BulletSpdUp_3		= 1 << 9,			// 총알 속도 증가.					Data

	PowerUp_1			= 1 << 10,			// 파워 증가.						Data
	PowerUp_2			= 1 << 11,			// 파워 증가.						Data
	PowerUp_3			= 1 << 12,			// 파워 증가.						Data

	HpUp_1				= 1 << 13,			// 체력 증가.						Data
	HpUp_2				= 1 << 14,			// 체력 증가.						Data
	HpUp_3				= 1 << 15,			// 체력 증가.						Data

	MovSpdUp_1			= 1 << 16,			// 이동속도 증가.						Data
	MovSpdUp_2			= 1 << 17,			// 이동속도 증가.						Data
	MovSpdUp_3			= 1 << 18,			// 이동속도 증가.						Data

	AroundBall			= 1 << 19,			// 원을 그리며 보호하는 물체 소환		Data + Component
	//TimerUp				= 1 << 20,			// 시간정지 시간 증가.				Data
	Penetrate			= 1 << 21,			// 관통 샷							Data

	//JumpUp				= 1 << 22,			// 점프력 증가.						Data
	//DoubleJump			= 1 << 23,			// 이단 점프.						Data
	//Dash				= 1 << 22,

	Flame				= 1 << 24,			// 지나간 길에 불길					Data + Component
	//IceShot				= 1 << 25,			// 얼음 샷.							Data

	Healing_1			= 1 << 26,			// 초당 체력 1씩 상승					Data + Component
	Healing_2			= 1 << 27,			// 초당 체력 1씩 상승					Data + Component
	Healing_3			= 1 << 28,			// 초당 체력 1씩 상승					Data + Component
}


public class Ability : MonoBehaviour
{
	public Character c;

	public virtual void Init(Character c)
	{
		this.c = c;
	}


}

