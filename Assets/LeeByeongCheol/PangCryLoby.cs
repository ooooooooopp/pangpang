using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PangCryLoby : MonoBehaviour
{

    private bool isClick = false;

    // Update is called once per frame
    void Update()
    {
        if (!isClick)
        {

            if (Input.GetKey(KeyCode.Space))
            {
                isClick = true;
                FadeInOut.Inst.FadeOut(2, "Choice");
            }
            else if (Input.GetMouseButton(0))
            {
                isClick = true;
                FadeInOut.Inst.FadeOut(2, "Choice");
            }
        }

    }
}
