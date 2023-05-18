using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    public float airForce = 10f;
    
    void Update()
    {
      
    }

 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            Vector2 forceDirection = transform.up; // или используйте свою собственную направленность воздушного потока
            rb.AddForce(forceDirection * airForce);
        }
    }


}
