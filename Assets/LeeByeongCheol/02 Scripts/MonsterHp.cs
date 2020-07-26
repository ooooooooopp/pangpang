using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterHp : MonoBehaviour , IDamagable
{
    // Start is called before the first frame update

    public float initHp = 1000.0f;
    public float currHp;

    public Image hpBar;

    Coroutine hitCo = null;

    public Vector2 startForce;

    public GameObject nextBall;

    public Rigidbody2D rb;

    public float damagePower;

    public SpriteRenderer spr;

    public GameObject coin;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(startForce, ForceMode2D.Impulse);
        currHp = initHp;
        spr = GetComponent<SpriteRenderer>();


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
        if ( !gameObject.activeInHierarchy )
            return false;

        if ( currHp <= 0f )
            return false;

        //if(!this.gameObject.activeSelf)
        //{
        //    return false;
        //}
        currHp -= data.damage;

        hpBar.fillAmount = (currHp / initHp);

        if ( hitCo != null ) StopCoroutine( hitCo );
        hitCo = StartCoroutine( InBeatTime() );

        if (currHp <= 0f)
        {
            //CoinDrop();
            MonsterDie();
            return true;
        }
        return false;
    }

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

    
    IEnumerator InBeatTime()
    {
        int countTime = 0;
        while (countTime < 10)
        {
            if(countTime%2 ==0)
            {
                spr.color = new Color32(255, 255, 255, 90);
         
            }
            else
            {
                spr.color = new Color32(255, 255, 255, 180);

                
            }
            yield return new WaitForSeconds(0.2f);

            countTime++;

        }
        spr.color = new Color32(255, 255, 255, 255);

        yield return null;

    }


    void CoinDrop()
    {
        for (int i = 0; i < Random.Range(0, 2) ;i++)
        {

            GameObject CoinClone = Instantiate(coin, transform.position, transform.rotation);
            

        }    

    }

}
