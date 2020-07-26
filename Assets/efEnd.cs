using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class efEnd : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnEnable()
    {
        Invoke("endEF", 0.6f);
    }


    void endEF()
    {
        this.gameObject.SetActive(false);
    }
}
