﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    public Rigidbody2D rb;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        StartCoroutine(WaitClearRoomCoin());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Wall")
        {
            Debug.Log("걸림");
            rb.simulated = false;
        }

      
            if (collision.tag == "Player")
        {
            if (StageManager.Inst.isClearRoom)
            {
                //코인사운드;
                this.gameObject.SetActive(false);
            }
        }
    }

    IEnumerator WaitClearRoomCoin()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            while (StageManager.Inst.isClearRoom)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(player.transform.position.x, player.transform.position.y+0.5f, player.transform.position.z), 0.2f);
                yield return null;
            }
        }
    }




}

