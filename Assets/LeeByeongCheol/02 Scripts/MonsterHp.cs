﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterHp : MonoBehaviour , IDamagable
{
    // Start is called before the first frame update

    public float initHp = 100.0f;
    public float currHp;

    public Image hpBar;


    public Vector2 startForce;

    public GameObject nextBall;

    public Rigidbody2D rb;

    public float damagePower;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(startForce, ForceMode2D.Impulse);
        currHp = initHp;
        
    }

    /*
    public void Damage(float _power)
    {

        currHp -= _power;
            hpBar.fillAmount = (currHp / initHp);
        if (currHp <= 0.0f)
        {
            MonsterDie();
        }
    }
    */

    private void MonsterDie()
    {

            if (nextBall != null)
            {
                GameObject ball1 = Instantiate(nextBall, rb.position + Vector2.right / 4f, Quaternion.identity);
                GameObject ball2 = Instantiate(nextBall, rb.position + Vector2.left / 4f, Quaternion.identity);

                ball1.GetComponent<MonsterHp>().startForce = new Vector2(2f, 5f);
                ball2.GetComponent<MonsterHp>().startForce = new Vector2(-2f, 5f);
            }
            else
            {
                StageManager.Inst.MonsterDie();

            }
        
        this.gameObject.SetActive(false);

    }


    public bool TakeDamage(DamagableData data)
    {
        currHp -= data.damage;

        hpBar.fillAmount = (currHp / initHp);
        if (currHp <= 0.0f)
        {
            MonsterDie();
            return true;
        }
        return false;
    }

    public float power = 50f;
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == TagName.PLAYER)
        {
            col.transform.GetComponent<IDamagable>().TakeDamage(new DamagableData()
            {
                damage = power,
                attacker = gameObject,
            });
        }
    }


}