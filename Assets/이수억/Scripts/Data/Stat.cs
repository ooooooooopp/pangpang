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
    public float atk;
    public float hp;
    public float maxHp;
    public float movSpd;
    
    public float bulletSpd;
    public int bulletCount;
    public int maxBulletCount;

    public float divTime;
    public float stopTime;
    public float jumpPower;

    public float healing;

    public void Init()
    {
        atk = 100;
        maxHp = 100;
        hp = maxHp;
        movSpd = 2f;

        bulletSpd = 2f;
        maxBulletCount = 1;
        bulletCount = maxBulletCount;

        divTime = 5f;
        stopTime = 5f;
        jumpPower = 100f;

        healing = 0f;
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
                maxBulletCount += 1;
                break;
            case AbilityKind.BulletBonus_2:
                maxBulletCount += 2;
                break;
            case AbilityKind.BulletBonus_3:
                maxBulletCount += 3;
                break;
            case AbilityKind.Divine:
                divTime += 5f;
                break;
            case AbilityKind.BulletSpdUp_1:
                bulletSpd += 2f;
                break;
            case AbilityKind.BulletSpdUp_2:
                bulletSpd += 4f;
                break;
            case AbilityKind.BulletSpdUp_3:
                bulletSpd += 6f;
                break;
            case AbilityKind.PowerUp_1:
                atk += 50f;
                break;
            case AbilityKind.PowerUp_2:
                atk += 100f;
                break;
            case AbilityKind.PowerUp_3:
                atk += 150f;
                break;
            case AbilityKind.HpUp_1:
                maxHp += 100f;
                break;
            case AbilityKind.HpUp_2:
                maxHp += 150f;
                break;
            case AbilityKind.HpUp_3:
                maxHp += 200f;
                break;
            case AbilityKind.MovSpdUp_1:
                movSpd += 2f;
                break;
            case AbilityKind.MovSpdUp_2:
                movSpd += 2f;
                break;
            case AbilityKind.MovSpdUp_3:
                movSpd += 2f;
                break;
            case AbilityKind.AroundBall:
                break;
            case AbilityKind.TimerUp:
                stopTime = 5f;
                break;
            case AbilityKind.Penetrate:
                break;
            case AbilityKind.JumpUp:
                jumpPower += 10f;
                break;
            case AbilityKind.DoubleJump:
                break;
            case AbilityKind.Flame:
                break;
            case AbilityKind.IceShot:
                break;
            case AbilityKind.Healing_1:
                healing += 5f;
                break;
            case AbilityKind.Healing_2:
                healing += 10f;
                break;
            case AbilityKind.Healing_3:
                healing += 15f;
                break;
            default:
                break;
        }
    }
}