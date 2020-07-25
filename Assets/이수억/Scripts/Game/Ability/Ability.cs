using UnityEngine;

public enum AbilityKind
{
	None				= 0,

	Double				= 1 << 1,			// 탄이 두개가 쌍으로 나감.		
	Triple				= 1 << 2,			// 3갈래 탄이됨					

	BulletBonus_1		= 1 << 3,			// 장탄수 증가 1단계.				
	BulletBonus_2		= 1 << 4,           // 장탄수 증가 2단계.				
	BulletBonus_3		= 1 << 5,           // 장탄수 증가 3단계.				

	Divine				= 1 << 6,			// 랜덤하게 무적됨				
	
	BulletSpdUp_1		= 1 << 7,			// 총알 속도 증가 1단계			
	BulletSpdUp_2		= 1 << 8,			// 총알 속도 증가 2단계			
	BulletSpdUp_3		= 1 << 9,           // 총알 속도 증가 3단계			

	PowerUp_1			= 1 << 10,			// 파워 증가 1단계				
	PowerUp_2			= 1 << 11,			// 파워 증가 2단계				
	PowerUp_3			= 1 << 12,          // 파워 증가 3단계				

	HpUp_1				= 1 << 13,			// 체력 증가 1단계				
	HpUp_2				= 1 << 14,			// 체력 증가 2단계				
	HpUp_3				= 1 << 15,          // 체력 증가 3단계				

	MovSpdUp_1			= 1 << 16,			// 이동속도 증가 1단계			
	MovSpdUp_2			= 1 << 17,			// 이동속도 증가 2단계			
	MovSpdUp_3			= 1 << 18,          // 이동속도 증가 3단계			

	AroundBall			= 1 << 19,			// 원을 그리며 보호하는 물체 소환	
	Penetrate			= 1 << 20,			// 관통 샷						

	Flame				= 1 << 21,			// 지나간 길에 불길				

	Healing_1			= 1 << 22,			// 초당 체력 상승 1단계			
	Healing_2			= 1 << 23,          // 초당 체력 상승 2단계			
	Healing_3			= 1 << 24,			// 초당 체력 상승	 3단계			
}


public class Ability : MonoBehaviour
{
	[HideInInspector]
	public Character c;

	public virtual void Init(Character c)
	{
		this.c = c;
	}


}

