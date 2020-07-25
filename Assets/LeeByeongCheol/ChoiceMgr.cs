using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceMgr : MonoBehaviour
{

    public GameObject but1;
    public GameObject but2;
    public GameObject but3;
    public GameObject but4;

    private bool isGirl;

    // Start is called before the first frame update
    void Start()
    {
        isGirl = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {

            isGirl = false;
            if (!isGirl)
            {
                but1.SetActive(true);
                but2.SetActive(false);
                but3.SetActive(false);
                but4.SetActive(true);
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            isGirl = true;
            if (isGirl)
            {
                but1.SetActive(false);
                but2.SetActive(true);
                but3.SetActive(true);
                but4.SetActive(false);
            }
        }

        else if (Input.GetKeyDown(KeyCode.Space))
        {
            if(isGirl)
            {
                GameManager._inst.isGirlChoice = true;
            
                FadeInOut.Inst.FadeOut(2, "Play");
            }
            else
            {
                GameManager._inst.isGirlChoice = false;
                FadeInOut.Inst.FadeOut(2, "Play");
            }
        }

    }


    public void butt1()
    {
        GameManager._inst.isGirlChoice = true;

        FadeInOut.Inst.FadeOut(2, "Play");
    }
    public void butt2()
    {
        but1.SetActive(true);
        but2.SetActive(false);
        but3.SetActive(false);
        but4.SetActive(true);
    }

    public void butt3()
    {
        GameManager._inst.isGirlChoice = false;
        FadeInOut.Inst.FadeOut(2, "Play");
    }
    public void butt4()
    {
        but1.SetActive(false);
        but2.SetActive(true);
        but3.SetActive(true);
        but4.SetActive(false);
    }
}
