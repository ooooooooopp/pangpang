using UnityEngine;

public enum AbilityKind
{
	None			= 0,

	Double			= 1 << 1,			// 위로 두개가 쌍으로 나감.			Data
	Triple			= 1 << 2,			// 3갈래 탄이됨						Data
	BulletBonus		= 1 << 3,			// 연달아서 쓸수 있게됨				Data

	Divine			= 1 << 4,			// 무적시간 증가.						Data
	
	BulletSpdUp		= 1 << 5,			// 총알 속도 증가.					Data

	PowerUp			= 1 << 6,			// 파워 증가.						Data
	HpUp			= 1 << 7,			// 체력 증가.						Data
	MovSpdUp		= 1 << 8,			// 이동속도 증가.						Data

	AroundBall		= 1 << 9,			// 원을 그리며 보호하는 물체 소환		Data + Component
	TimerUp			= 1 << 10,			// 시간정지 시간 증가.				Data
	Penetrate		= 1 << 11,			// 관통 샷							Data

	JumpUp			= 1 << 12,			// 점프력 증가.						Data
	DoubleJump		= 1 << 13,			// 이단 점프.						Data

	Flame			= 1 << 14,			// 지나간 길에 불길					Data + Component
	IceShot			= 1 << 15,			// 얼음 샷.							Data

	Healing			= 1 << 16,			// 초당 체력 1씩 상승					Data + Component
}


public class Ability : MonoBehaviour
{



}

