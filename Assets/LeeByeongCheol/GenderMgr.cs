using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenderMgr : MonoBehaviour
{
    public Character character;

    public GameObject imaG;
    public GameObject imaM;
    // Start is called before the first frame update
    void Start()
    {
        GenderCheck();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenderCheck()
    {
        if (GameManager._inst.isGirlChoice)
        {
            character.gender = CharKind.woman;
            imaG.SetActive(true);
            imaM.SetActive(false);
        }
        else if(GameManager._inst.isGirlChoice == false)
        {
            character.gender = CharKind.man;
            imaG.SetActive(false);
            imaM.SetActive(true);
        }

    }
}
