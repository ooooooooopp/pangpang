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

	public static string GetExplain(AbilityKind kind)
	{
		switch ( kind ) {
			case AbilityKind.None:
				break;
			case AbilityKind.Double:
				return "미사일이 두개";
			case AbilityKind.Triple:
				return "3갈래 탄";
			case AbilityKind.BulletBonus_1:
				return "총알 추가 Lv1";
			case AbilityKind.BulletBonus_2:
				return "총알 추가 Lv2";
			case AbilityKind.BulletBonus_3:
				return "총알 추가 Lv3";
			case AbilityKind.Divine:
				return "간헐적 무적";
			case AbilityKind.BulletSpdUp_1:
				return "총알 속도증가 Lv1";
			case AbilityKind.BulletSpdUp_2:
				return "총알 속도증가 Lv2";
			case AbilityKind.BulletSpdUp_3:
				return "총알 속도증가 Lv3";
			case AbilityKind.PowerUp_1:
				return "공격력 증가 Lv1";
			case AbilityKind.PowerUp_2:
				return "공격력 증가 Lv2";
			case AbilityKind.PowerUp_3:
				return "공격력 증가 Lv3";
			case AbilityKind.HpUp_1:
				return "체력 증가 Lv1";
			case AbilityKind.HpUp_2:
				return "체력 증가 Lv2";
			case AbilityKind.HpUp_3:
				return "체력 증가 Lv3";
			case AbilityKind.MovSpdUp_1:
				return "이동속도증가 Lv1";
			case AbilityKind.MovSpdUp_2:
				return "이동속도증가 Lv2";
			case AbilityKind.MovSpdUp_3:
				return "이동속도증가 Lv3";
			case AbilityKind.AroundBall:
				return "빙빙돌이";
			case AbilityKind.Penetrate:
				return "관통";
			case AbilityKind.Flame:
				return "불길생성";
			case AbilityKind.Healing_1:
				return "체력 재생 Lv1";
			case AbilityKind.Healing_2:
				return "체력 재생 Lv2";
			case AbilityKind.Healing_3:
				return "체력 재생 Lv3";
			default:
				break;
		}
		return string.Empty;
	}


}

