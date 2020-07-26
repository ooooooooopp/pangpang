using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStone : MonoBehaviour
{

    private float _time = 0f;
    private Rigidbody2D rb;
    public float power = 50f;
    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
    }
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
    void Update()
    {
        _time += Time.deltaTime;

        Vector3 _target = new Vector3(transform.position.x, -100f, 0f);
        transform.position = Vector3.MoveTowards(transform.position, _target, 0.15f);

        if (_time > 3f)
        {
            _time = 0f;
            Destroy(gameObject);
        }


    }
}
