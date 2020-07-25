﻿using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

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

   
    public int stageIndex;
    public int waveIndex;
    public int monsterCount;
    public int monsterFinalCount;


    public GameObject[] stage;

    public GameObject ability;
    public bool isSlotMachine = false;
    public bool isClearRoom = false;
    // Start is called before the first frame update
    void Start()
    {

        waveIndex = 0;
        StageOpen();
        
    }



    public void MonsterDie()
    {
        monsterCount++;

        if (monsterCount >= monsterFinalCount)
        {
            //동전획득 후 진행
            isClearRoom = true;

            switch (waveIndex) //삼지선다
            {
                case 2:
                    
                    isSlotMachine = true;
                    ability.SetActive(true);
                    break;
                case 5:
                    isSlotMachine = true;
                    ability.SetActive(true);
                    break;
                case 8:
                    isSlotMachine = true;
                    ability.SetActive(true);
                    break;
            }

            if(!isSlotMachine)
            {
                FadeInOut.Inst.FadeOut(2f);
                StartCoroutine(WaitForItFade());

            }



        }
    }

    void StageClear()
    {
        FadeInOut.Inst.FadeOut(3);
        Debug.Log("스테이지 격파");
    }



    private void StageOpen()
    {

        //씬 전환 시 정보 스테이지 정보 받아오고 진행 필요
        //stageIndex = ;

        stageIndex = 0; //임시
        switch (stageIndex)
        {
            case 0: 
                stage[0].SetActive(true);

                break;
            case 1:
                stage[1].SetActive(true);
                break;
            case 2:
                stage[2].SetActive(true);
                break;
        }
        WaveOpen();
    }

    private void WaveOpen()
    {
        isClearRoom = false;
        stage[stageIndex].GetComponent<Wave>().wave[waveIndex].gameObject.SetActive(true);
        monsterFinalCount = stage[stageIndex].GetComponent<Wave>().monsterCount[waveIndex];
        //monsterFinalCount = 1;

        /*테스트 
         waveIndex = 2;
         stage[stageIndex].GetComponent<Wave>().wave[waveIndex].gameObject.SetActive(true);
         monsterFinalCount = 1;
         */
    }


    public void SlotMachineEnd()
    {
        isSlotMachine = false;
        FadeInOut.Inst.FadeOut(2f);
        StartCoroutine(WaitForItFade());
      
    }


    IEnumerator WaitForItFade()
    {

        yield return new WaitForSeconds(2.0f);
        stage[stageIndex].GetComponent<Wave>().wave[waveIndex].gameObject.SetActive(false);
        waveIndex++;


        if (waveIndex > 10)
        {
            StageClear();
        }
        else
        {

            FadeInOut.Inst.FadeIn(1);
            WaveOpen();
        }

    }


}
