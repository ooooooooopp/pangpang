using Microsoft.Win32;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour,IDamagable
{
    private bool rageboss = true;  //보스 체력이 40퍼 이하일때 true가 됨.
    private Animator ani;

    public float initHp = 10000.0f;
    public float curHp;

    public Image hpBar;

    Coroutine attackCo = null;
    Coroutine chopCo = null;
    Coroutine rushCo = null;
    public SpriteRenderer spr1;
    public SpriteRenderer spr2;
    public SpriteRenderer spr3;
    public SpriteRenderer spr4;
    public SpriteRenderer spr5;
    public SpriteRenderer spr6;
    public SpriteRenderer spr7;
    public SpriteRenderer spr8;
    public SpriteRenderer spr9;
    public SpriteRenderer spr10;
    public SpriteRenderer spr11;
    public SpriteRenderer spr12;
    public SpriteRenderer spr13;
    public SpriteRenderer spr14;
    public SpriteRenderer spr15;

    public GameObject coin;

    public GameObject[] AttackObj = new GameObject[4];


    private void Awake()
    {
        ani = GetComponent<Animator>();

    }

    void Start()
    {
        curHp = initHp;
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            RushAttack();
        }

    }

    public bool TakeDamage(DamagableData data)
    {
        Debug.Log("맞았다");
        curHp -= data.damage;

        hpBar.fillAmount = (curHp / initHp);
        StartCoroutine(InBeatTime());

        if (curHp > 0f && curHp <= 0.4f)
        {
            rageboss = true;
        }
        else if (curHp <= 0.0f)
        {
            CoinDrop();
            BossDie();

            return true;
        }
        return false;
    }


    private void OnEnable()
    {
        if (attackCo != null)
            attackCo = null;


         BossSkill();
    }

    IEnumerator InBeatTime()
    {
        int countTime = 0;
        while (countTime < 10)
        {
            if (countTime % 2 == 0)
            {
                spr1.color = new Color32(255, 255, 255, 90);
                spr2.color = new Color32(255, 255, 255, 90);
                spr3.color = new Color32(255, 255, 255, 90);
                spr4.color = new Color32(255, 255, 255, 90);
                spr5.color = new Color32(255, 255, 255, 90);
                spr6.color = new Color32(255, 255, 255, 90);
                spr7.color = new Color32(255, 255, 255, 90);
                spr8.color = new Color32(255, 255, 255, 90);
                spr9.color = new Color32(255, 255, 255, 90);
                spr10.color = new Color32(255, 255, 255, 90);
                spr11.color = new Color32(255, 255, 255, 90);
                spr12.color = new Color32(255, 255, 255, 90);
                spr13.color = new Color32(255, 255, 255, 90);
                spr14.color = new Color32(255, 255, 255, 90);
                spr15.color = new Color32(255, 255, 255, 90);
            }
            else
            {
                spr1.color = new Color32(255, 255, 255, 180);
                spr2.color = new Color32(255, 255, 255, 180);
                spr3.color = new Color32(255, 255, 255, 180);
                spr4.color = new Color32(255, 255, 255, 180);
                spr5.color = new Color32(255, 255, 255, 180);
                spr6.color = new Color32(255, 255, 255, 180);
                spr7.color = new Color32(255, 255, 255, 180);
                spr8.color = new Color32(255, 255, 255, 180);
                spr9.color = new Color32(255, 255, 255, 180);
                spr10.color = new Color32(255, 255, 255, 180);
                spr11.color = new Color32(255, 255, 255, 180);
                spr12.color = new Color32(255, 255, 255, 180);
                spr13.color = new Color32(255, 255, 255, 180);
                spr14.color = new Color32(255, 255, 255, 180);
                spr15.color = new Color32(255, 255, 255, 180);
            }
            yield return new WaitForSeconds(0.2f);

            countTime++;

        }
        spr1.color = new Color32(255, 255, 255, 255);
        spr2.color = new Color32(255, 255, 255, 255);
        spr3.color = new Color32(255, 255, 255, 255);
        spr4.color = new Color32(255, 255, 255, 255);
        spr5.color = new Color32(255, 255, 255, 255);
        spr6.color = new Color32(255, 255, 255, 255);
        spr7.color = new Color32(255, 255, 255, 255);
        spr8.color = new Color32(255, 255, 255, 255);
        spr9.color = new Color32(255, 255, 255, 255);
        spr10.color = new Color32(255, 255, 255, 255);
        spr11.color = new Color32(255, 255, 255, 255);
        spr12.color = new Color32(255, 255, 255, 255);
        spr13.color = new Color32(255, 255, 255, 255);
        spr14.color = new Color32(255, 255, 255, 255);
        spr15.color = new Color32(255, 255, 255, 255);

        yield return null;

    }

    private void BossSkill()
    {
        //보스는 총 3가지 패턴을 갖고 있고, 체력이 50퍼 이하 일때 4번째 패턴이 발생한다. 
        //3가지 패턴일때 1번스킬 확률 35%, 2번스킬 확률 45%, 3번스킬 확률 20%
        //4가지 패턴일때 1번스킬 확률 30%, 2번스킬 확률 20%, 3번스킬 확률 20%, 4번스킬 확률 30%

        int skill = Random.Range(0, 100);
        int skillnumber;
        if (!rageboss)
        {
            if (skill < 35)
            {
                skillnumber = 1;
            }
            else if (skill < 80)
            {
                skillnumber = 2;
            }
            else
            {
                skillnumber = 3;
            }
            if ( attackCo != null ) 
                attackCo = null;
            
            attackCo = StartCoroutine(BossBasicCoroutine(skillnumber));	
        }
        else
        {
            if (skill < 30)
            {
                skillnumber = 1;
            }
            else if (skill < 50)
            {
                skillnumber = 2;
            }
            else if(skill<70)
            {
                skillnumber = 3;
            }
            else
            {
                skillnumber =4;
            }
            if (attackCo != null)
                attackCo = null;

            attackCo = StartCoroutine(BossRageCoroutine(skillnumber));
        }
    }

    //skill 1번 

    IEnumerator BossBasicCoroutine(int t)
    {
        switch (t)
        {
            case 1:
                float one = Random.Range(5f, 7f);
                yield return new WaitForSeconds(one);

                //박수 치는 애니메이션
                ani.Play("BossAttackOne");

                yield return new WaitForSeconds(3f);
                break;
            case 2:
                float two = Random.Range(3f, 4f);
                yield return new WaitForSeconds(two);

                //알 쏘는 애니메이션
                ani.Play("BossAttackTwo");
                yield return new WaitForSeconds(4f);
                //알 오브젝트 생성
                break;
            case 3:
                float thr = Random.Range(5f, 8f);
                yield return new WaitForSeconds(thr);

                //손찌르기 애니메이션
                ani.Play("BossAttackThr");
                yield return new WaitForSeconds(4f);
                //손찌르기 공격 오브젝트 생성

                break;
            default:
                break;
        }

    }


    IEnumerator BossRageCoroutine(int t)
    {
        switch (t)
        {
            case 1:
                float one = Random.Range(4f, 5.5f);
                yield return new WaitForSeconds(one);

                //박수 치는 애니메이션
                ani.Play("BossAttackOne");
                yield return new WaitForSeconds(2.5f);
                break;
            case 2:
                float two = Random.Range(2f, 3f);
                yield return new WaitForSeconds(two);

                //알 쏘는 애니메이션
                ani.Play("BossAttackTwo");
                yield return new WaitForSeconds(1.5f);
                break;
            case 3:
                float thr = Random.Range(3f, 5f);
                yield return new WaitForSeconds(thr);

                //손찌르기 애니메이션
                ani.Play("BossAttackThr");
                yield return new WaitForSeconds(3f);
                //손찌르기 공격 오브젝트 생성
                break;
            case 4:
                float fou = Random.Range(2f,4f);
                yield return new WaitForSeconds(fou);

                //벽 내리기 애니메이션
                ani.Play("BossAttackFor");
                yield return new WaitForSeconds(3f);
                //쏟아지는 벽 생성
                break;
            default:
                break;
        }


    }
    public void Attackfx(int z)
    {
        switch (z)
        {
            case 1:
                /*
                Debug.Log("첫번째 공격 장풍");
                var c = Instantiate(AttackObj[0]);
                c.transform.SetParent(gameObject.transform);
                c.GetComponent<Transform>().localPosition = new Vector3(0f, 2f, 0f);
                BossSkill();
                */
                break;
            case 2:
                Debug.Log("두번째 공격 알쏘기");
                var d = Instantiate(AttackObj[1]);
                d.transform.SetParent(gameObject.transform);
                d.GetComponent<Transform>().localPosition = new Vector3(0f, 2f, 0f);
                BossSkill();
                break;
            case 3:
                Debug.Log("세번째 공격 땅에서 손올리기");

                ChopAttack();
                break;
            case 4:
                Debug.Log("네번째 공격 하늘에서 비석떨구기");

                RushAttack();
                break;
            default:
                break;
        }
    }

    private void ChopAttack()
    {
        if (chopCo != null)
            chopCo = null;

        chopCo = StartCoroutine(ChopCoroutine());
    }

    private void RushAttack()
    {
        if (rushCo != null)
            rushCo = null;

        rushCo = StartCoroutine(RushCoroutine());
    }


    IEnumerator ChopCoroutine()
    {
        int y = Random.Range(4, 8);
        for (int i = 0; i < y; i++)
        {
            yield return new WaitForSeconds(1.2f);

            var e = Instantiate(AttackObj[2]);
            e.transform.SetParent(gameObject.transform);
            e.GetComponent<Transform>().localPosition = new Vector3(1f-i,-4f,0f);
        }

        ani.Play("BossAttackThr3");
        BossSkill();

    }

    IEnumerator RushCoroutine()
    {
        int x = Random.Range(4, 8);
        for (int i = 0; i < x; i++)
        {
            yield return new WaitForSeconds(1f);
            float g = Random.Range(-10f, 1f);
            var f = Instantiate(AttackObj[3]);
            f.transform.SetParent(gameObject.transform);
            f.GetComponent<Transform>().localPosition = new Vector3(g,10f, 0f);
        }
        ani.Play("BossAttackFor3");
        BossSkill();

    }



    private void BossDie()
    {
       //모든 오브젝트가 즉시 사라지고 플레이어가 무적이 됨. 
       //StageManager.Inst.BossDie();

        this.gameObject.SetActive(false);

    }


    void CoinDrop()
    {
        for (int i = 0; i < Random.Range(5, 20); i++)
        {
            GameObject CoinClone = Instantiate(coin, transform.position, transform.rotation);
        }

    }

}
