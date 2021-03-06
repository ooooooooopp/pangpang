﻿public class Balance
{
    //케릭터 능력 시작값
    public const float ATK = 100f;
    public const float HP = 1000f;
    public const float MOV_SPD = 3f;
    public const float BULLET_SPD = 2f;
    public const int BULLET_COUNT = 1;

    public const float DIVINE_TIME = 2f;            //무적이 지속되는 시간, 무적이 걸리는건 랜덤합니다. (1f ~ 5f)
    public const float DIVINE_TERM_MIN = 1f;
    public const float DIVINE_TERM_MAX = 5f;

    //public const float STOP_TIME = 5f;          //정지시간
    //public const float JUMP_POWER = 100f;       //점프 힘

    //어빌리티로 증가하는 수치 량.
    //단계가 있는 능력들은 중첩됩니다.

    public const int BULLET_BONUS_1 = 1;                //장탄수 증가.
    public const int BULLET_BONUS_2 = 1;
    public const int BULLET_BONUS_3 = 1;

    public const float BULLET_SPD_1 = 2f;                 //총알 속도증가.
    public const float BULLET_SPD_2 = 2f;                 //총알 속도증가.
    public const float BULLET_SPD_3 = 2f;                 //총알 속도증가.

    public const float DAMAGE_INC_1 = 10f;                  //공격력 증가량
    public const float DAMAGE_INC_2 = 20f;
    public const float DAMAGE_INC_3 = 30f;

    public const float MAX_HP_INC_1 = 30f;             //최대 체력 증가량
    public const float MAX_HP_INC_2 = 70f;
    public const float MAX_HP_INC_3 = 100f;

    public const float MOV_SPD_INC_1 = 2f;
    public const float MOV_SPD_INC_2 = 2f;
    public const float MOV_SPD_INC_3 = 2f;

    public const float HEALING_INC_1 = 5f;              //체력 회복량
    public const float HEALING_INC_2 = 10f;
    public const float HEALING_INC_3 = 15f;

    public const float HEALING_TERM = 1f;               //힐이 들어가는 간격

    //public const float JUMP_POWER_UP = 10f;
}
