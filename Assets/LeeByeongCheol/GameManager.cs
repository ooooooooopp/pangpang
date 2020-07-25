using Sirenix.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonKeep<GameManager>
{
    public bool isGirlChoice;
    private void Awake()
    {
        if (GameManager._inst != null)
        {
            Destroy(this.gameObject);
        }

    }

    void Start()
    {
        GameManager.Inst.Load();


    }

    void Update()
    {

    }
    //
    void Load()
    {

    }
}

