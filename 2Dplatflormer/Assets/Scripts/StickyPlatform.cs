using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    //// Start is called before the first frame update
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
        
    //}
    //private void OnCollisionExit2D(Collision2D collision)
    //{
        
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Hero"))
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Hero"))
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
