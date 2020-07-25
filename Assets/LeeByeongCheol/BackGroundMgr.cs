using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackGroundMgr : MonoBehaviour
{
    public Sprite[] spr;
    public SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {

    }



    public int sprIndex = 0;

    public void BGChange()
    {
        sr.sprite = spr[sprIndex];
        sprIndex++;
    }
}

