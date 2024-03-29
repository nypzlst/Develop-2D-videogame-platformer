using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private Rigidbody2D rb;
    public float destroyFalling = 1.5f;
    public float platformFallTime =2f;
    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Hero"))
        {
            Invoke("Fall", platformFallTime);
        }
    }
    void Fall()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        Invoke("Destroi", destroyFalling);
        //rb.velocity = new Vector2(rb.velocity.x, platformFall);
    }
    void Destroi()
    {
        Destroy(gameObject);
    }
}
