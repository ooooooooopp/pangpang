using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowMonster : MonoBehaviour
{
    // Start is called before the first frame update
    int randomIndex;
    private Transform tr;
    public float speed;
    void Start()
    {

        tr = GetComponent<Transform>();
        randomIndex = Random.Range(0, 3);

    }

    // Update is called once per frame
    void Update()
    {

        switch(randomIndex)
        {
            
            case 0:
                tr.Translate(Vector3.up * speed * Time.deltaTime);
                break;
            case 1:
                tr.Translate(Vector3.down * speed * Time.deltaTime);
                break;
            case 2:
                tr.Translate(Vector3.right * speed * Time.deltaTime);
                break;
            case 3:
                tr.Translate(Vector3.left * speed * Time.deltaTime);
                break;
        }
      

    }





    public void OnTriggerEnter2D(Collider2D col)
    {

        if(col.gameObject.name == "Wall_Bottom")
        {
            randomIndex = 0;
        }
        else if(col.gameObject.name == "Wall_Top")
        {
            randomIndex = 1;
        }
        else if (col.gameObject.name == "Wall_Left")
        {
            randomIndex = 2;
        }
        else if (col.gameObject.name == "Wall_Right")
        {
            randomIndex = 3;
        }

    }

}
