using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TriggerFallingPlatformForNextLvl : MonoBehaviour
{
    public static Action onFallingPlatform;
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hero"))
        {
            isFalling();
        }
    }
    private void isFalling()
    {
        onFallingPlatform?.Invoke();
    }

}
