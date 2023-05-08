using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlippPlatform : MonoBehaviour
{
    public float timer = 2;

    void Start()
    {
        InvokeRepeating("Flip", timer, timer); 
    }

    void Flip()
    {
        transform.Rotate(new Vector3(180f, 0)); 
    }
}
