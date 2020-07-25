﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotMachineManager : MonoBehaviour
{
    public GameObject[] SlotSkillObject;
    public Button[] Slot;

    public Sprite[] SkillSprite;

    [System.Serializable]
    public class DisplayItemSlot
    {
        public List<Image> SlotSprite = new List<Image>();
    }
    public DisplayItemSlot[] DisplayItemSlots;



    public List<int> StartList = new List<int>();
    public List<int> ResultIndexList = new List<int>();
    int ItemCnt = 3;
    int[] answer = { 2, 2, 2 };

    public int buttonIndex;

    public GameObject button_0;
    public GameObject button_1;
    public GameObject button_2;

    public int[] check;
    // Start is called before the first frame update

    private void Awake()
    {
        check = new int[SkillSprite.Length];
        for (int m = 0; m < check.Length; m++)
        {
            check[m] = 0;

        }
      

    }
    void OnEnable()
    {

        for (int i = 0; i < ItemCnt * Slot.Length; i++)
        {
            StartList.Add(i);
            check[i] = 1;
        }


        for (int i = 0; i < Slot.Length; i++)
        {
            for (int j = 0; j < ItemCnt; j++)
            {
                Slot[i].interactable = false;

                int randomIndex = Random.Range(0, StartList.Count);


                if (i == 0 && j == 1 || i == 1 && j == 0 || i == 2 && j == 2)
                {
                    ResultIndexList.Add(StartList[randomIndex]);

                }

                if (SkillSprite[StartList[randomIndex]] != null)
                {
                    DisplayItemSlots[i].SlotSprite[j].sprite = SkillSprite[StartList[randomIndex]];
                }
                else
                {
                    Debug.Log("널입니다");
                    for (int m = 0; m < check.Length; m++)
                    {
                        if (check[m] == 0)
                        {
                            Debug.Log("널입니다1");
                            DisplayItemSlots[i].SlotSprite[j].sprite = SkillSprite[StartList[m]];
                            Debug.Log(SkillSprite[StartList[m]]);
                            break;
                        }

                    }

                }






                if (j == 0)
                {
                    DisplayItemSlots[i].SlotSprite[ItemCnt].sprite = SkillSprite[StartList[randomIndex]];
                    Debug.Log(DisplayItemSlots[i].SlotSprite[ItemCnt].sprite);
                    Debug.Log("테스트");
                }
                StartList.RemoveAt(randomIndex);
            }
        }

        for (int i = 0; i < Slot.Length; i++)
        {
            StartCoroutine(StartSlot(i));

        }
    }

    IEnumerator StartSlot(int SlotIndex)
    {

        for (int i = 0; i < 39; i++)
        {

            SlotSkillObject[SlotIndex].transform.localPosition -= new Vector3(0, 200f, 0);
            if (SlotSkillObject[SlotIndex].transform.localPosition.y < 200f)
            {
                SlotSkillObject[SlotIndex].transform.localPosition += new Vector3(0, 600, 0);

            }
            yield return new WaitForSeconds(0.05f);
        }
        for (int i = 0; i < ItemCnt; i++)
        {

            Slot[i].interactable = true;
        }


    }

    public void AbilityButtonClick(int index)
    {
        if (index == 0)
        {
            StageManager.Inst.SlotMachineEnd();

            buttonIndex = int.Parse(button_0.GetComponent<ButtonIndex>().buttonIndex.sprite.name);
            this.gameObject.SetActive(false);
        }
        else if (index == 1)
        {
            StageManager.Inst.SlotMachineEnd();
            buttonIndex = int.Parse(button_1.GetComponent<ButtonIndex>().buttonIndex.sprite.name);
            this.gameObject.SetActive(false);
        }
        else if (index == 2)
        {
            StageManager.Inst.SlotMachineEnd();
            buttonIndex = int.Parse(button_2.GetComponent<ButtonIndex>().buttonIndex.sprite.name);
            this.gameObject.SetActive(false);
        }

        check[buttonIndex - 1] = 1;



        //Debug.LogError(buttonIndex - 1);
        //SkillSprite[buttonIndex - 1] = null;
        //SkillSprite[buttonIndex - 1] =

        for (int i = 0; i < check.Length+3; i++)
        {
            if (check[i] == 0)
            {
                Debug.Log(i);
                check[i] = 1;
                SkillSprite[buttonIndex - 1] = SkillSprite[i];
                break;
            }

        }

    }
}

