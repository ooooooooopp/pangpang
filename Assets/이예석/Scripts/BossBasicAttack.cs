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
            var dmg = col.GetComponent<IDamagable>();
            if ( dmg != null ) {
                dmg.TakeDamage( new DamagableData() {
                    damage = power,
                    attacker = gameObject,
                } );
            }
        }
    }


}
