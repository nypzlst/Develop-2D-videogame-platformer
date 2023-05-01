using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Cinemachine;

public class GameEvents : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody2D rb;
    CinemachineVirtualCamera virtualCamera;

    private float timeToInvoke = 3f;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void OnEnable()
    {
        TriggerFallingPlatformForNextLvl.onFallingPlatform += FallingPlatformForNextLvl;
    }
    private void OnDisable()
    {
        TriggerFallingPlatformForNextLvl.onFallingPlatform -= FallingPlatformForNextLvl;
    }

    
    private void FallingPlatformForNextLvl()
    {
        FreezePositon();
        //virtualCamera.m_Lens.FieldOfView = 35f;



        Invoke("UnFreezePosition", timeToInvoke);


        Debug.Log("Falling platform its work");
    }

    private void FreezePositon()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        Debug.Log("Freeze its ok");
    }

    private void UnFreezePosition()
    {
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        Debug.Log("Unfreeze OK");
    }
}
