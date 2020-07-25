using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBasicAttack : MonoBehaviour
{

    public float power = 50f;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == TagName.PLAYER)
        {
            col.transform.GetComponent<IDamagable>().TakeDamage(new DamagableData()
            {
                damage = power,
                attacker = gameObject,
            }) ;
        }
    }


}
