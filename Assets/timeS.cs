using Sirenix.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timeS : MonoBehaviour
{
    public GameObject Cousor1;
    public GameObject Cousor2;

    public Transform tr;
    public SlotMachineManager slotMachineManager;
    public GameObject preFab;

    private void OnEnable()
    {
        skillCheck();
        Time.timeScale = 0;
        
    }
    private void OnDisable()
    {
        Time.timeScale = 1;
    }



    private bool isCousor = false;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            isCousor = false;
            Cousor1.SetActive(true);
            Cousor2.SetActive(false);
            AudioController.Play( "Ping" );

        } else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            isCousor = true;
            Cousor1.SetActive(false);
            Cousor2.SetActive(true);
            AudioController.Play( "Ping" );
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            if(!isCousor)
            {
                AudioController.Play( "Ping" );
                this.gameObject.SetActive(false);
            }
            else
            {
                Application.Quit();
            }
        }
    }


    void skillCheck()
    {
      
        if(slotMachineManager.sprList.Count >= 1)
        {

            
            for (int j=0; j < slotMachineManager.sprList.Count; j++)
            {
              
                GameObject aPrefab= Instantiate(preFab, transform.position, Quaternion.identity);
                aPrefab.GetComponent<Image>().sprite = slotMachineManager.sprList[j];
                aPrefab.transform.parent = tr;
                aPrefab.transform.position = new Vector2(0, 0);
               
            }
        }
        
    }
}
