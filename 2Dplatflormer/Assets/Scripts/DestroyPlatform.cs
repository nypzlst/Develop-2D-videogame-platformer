using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class DestroyPlatform : MonoBehaviour
{
    public float timeToDestroy ;
    public float timeToRespawn = 3f;
    public float timerStart = 3f;

     void Start()
    {
        timeToDestroy = timerStart;
    }

     void Update()
    {
        
        if(timeToDestroy> 0)
        {
            timeToDestroy -= Time.deltaTime;
        }
        else if(timeToDestroy <= 0)
        {
            Debug.Log("time destroy");
            gameObject.SetActive(false);
            
            Invoke("RespawnPlatform", timeToRespawn);
        }
    }

    private void RespawnPlatform()
    {
        gameObject.SetActive(true);
        timeToDestroy = timerStart;
    }
}
