using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    public float timeToDestroy = 1f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Hero"))
        {
            Invoke("OnDestroy", timeToDestroy);
        }
    }

    private void OnDestroy()
    {
        Destroy(gameObject);
    }
}
