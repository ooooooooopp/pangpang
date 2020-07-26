using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonOnE : MonoBehaviour
{
    private void OnDisable()
    {
        Destroy(this.gameObject);
    }
}
