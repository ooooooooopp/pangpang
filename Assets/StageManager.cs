using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    private static StageManager _inst = null;
    public static StageManager Inst
    {
        get
        {
            if (_inst == null)
            {
                _inst = FindObjectOfType(typeof(StageManager)) as StageManager;
            }
            return _inst;
        }
    }

    public Stage[] stage;
    public int stageIndex;
    private GameObject monsterPool;


    public int monsterCount;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MonsterDie()
    {
        monsterCount++;
        Debug.Log(monsterCount);

        if(monsterCount >= 5)
        {
            StageClear();
        }
    }

    void StageClear()
    {
        FadeInOut.Inst.FadeOut(3);
        Debug.Log("스테이지 격파");
    }
}
