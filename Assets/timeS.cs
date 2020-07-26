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
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            isCousor = true;
            Cousor1.SetActive(false);
            Cousor2.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            if(!isCousor)
            {
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
        Debug.Log("1");
        if(slotMachineManager.sprList.Count >= 1)
        {

            Debug.Log("1");
            for (int j=0; j < slotMachineManager.sprList.Count; j++)
            {
                Debug.Log("2");
                GameObject a= Instantiate(preFab, transform.position, Quaternion.identity);
                a.GetComponent<Image>().sprite = slotMachineManager.sprList[j];
                Debug.Log("3");
            }
        }
        
    }
}
