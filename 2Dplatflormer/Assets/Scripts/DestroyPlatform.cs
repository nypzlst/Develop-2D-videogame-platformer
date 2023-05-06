using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlatform1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Hero"))
        {
            Invoke("OnDestroy", 1f);
        }
    }

    private void OnDestroy()
    {
        Destroy(gameObject);
    }
}
