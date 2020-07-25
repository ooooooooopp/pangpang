using DevelopeCommon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatKind
{
    atk,
    hp,
    maxHp,
    movSpd,
    bulletSpd,
    bulletCount,
    maxBulletCount,
    divTime,
    stopTime,
    jumpPower,
    healing,
}

public class PlayerStat
{
    public Character c;

    public float atk;
    public float hp;
    public float maxHp;
    public float movSpd;
    
    public float bulletSpd;
    public int bulletCount => c.bulletCon.shots.Count;
    public int maxBulletCount;

    public float divTime;
    public float healing;

    public bool isDivine;
    public bool isDie => hp <= 0;

    public void Init(Character c)
    {
        this.c = c;

        atk = Balance.ATK;
        maxHp = Balance.HP;
        hp = Balance.HP;
        movSpd = Balance.MOV_SPD;

        bulletSpd = Balance.BULLET_SPD;
        maxBulletCount = Balance.BULLET_COUNT;

        divTime = Balance.DIVINE_TIME;
        //stopTime = Balance.STOP_TIME;
        //jumpPower = Balance.JUMP_POWER;
        healing = 0f;

        isDivine = false;
    }

    public void Heal(float adder )
    {
        hp += adder;
        if ( hp >= maxHp )
            hp = maxHp;

    }

    public void AddAbility(AbilityKind kind)
    {
        switch ( kind ) {
            case AbilityKind.None:
                break;
            case AbilityKind.Double:
                break;
            case AbilityKind.Triple:
                break;
            case AbilityKind.BulletBonus_1:
                maxBulletCount += Balance.BULLET_BONUS_1;
                break;
            case AbilityKind.BulletBonus_2:
                maxBulletCount += Balance.BULLET_BONUS_2;
                break;
            case AbilityKind.BulletBonus_3:
                maxBulletCount += Balance.BULLET_BONUS_3;
                break;
            case AbilityKind.Divine:
                break;
            case AbilityKind.BulletSpdUp_1:
                bulletSpd += Balance.BULLET_SPD_1;
                break;
            case AbilityKind.BulletSpdUp_2:
                bulletSpd += Balance.BULLET_SPD_2;
                break;
            case AbilityKind.BulletSpdUp_3:
                bulletSpd += Balance.BULLET_SPD_3;
                break;
            case AbilityKind.PowerUp_1:
                atk += Balance.DAMAGE_INC_1;
                break;
            case AbilityKind.PowerUp_2:
                atk += Balance.DAMAGE_INC_2;
                break;
            case AbilityKind.PowerUp_3:
                atk += Balance.DAMAGE_INC_3;
                break;
            case AbilityKind.HpUp_1:
                maxHp += Balance.MAX_HP_INC_1;
                break;
            case AbilityKind.HpUp_2:
                maxHp += Balance.MAX_HP_INC_2;
                break;
            case AbilityKind.HpUp_3:
                maxHp += Balance.MAX_HP_INC_3;
                break;
            case AbilityKind.MovSpdUp_1:
                movSpd += Balance.MOV_SPD_INC_1;
                break;
            case AbilityKind.MovSpdUp_2:
                movSpd += Balance.MOV_SPD_INC_2;
                break;
            case AbilityKind.MovSpdUp_3:
                movSpd += Balance.MOV_SPD_INC_3;
                break;
            case AbilityKind.AroundBall:
                break;
            case AbilityKind.Penetrate:
                break;
            case AbilityKind.Flame:
                break;
            case AbilityKind.Healing_1:
                healing += Balance.HEALING_INC_1;
                break;
            case AbilityKind.Healing_2:
                healing += Balance.HEALING_INC_2;
                break;
            case AbilityKind.Healing_3:
                healing += Balance.HEALING_INC_3;
                break;
            default:
                break;
        }
    }
}