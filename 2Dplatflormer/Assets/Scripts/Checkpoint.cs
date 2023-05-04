using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    Vector2 heroPosition;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hero"))
        {
            heroPosition= collision.transform.position;
            Debug.Log(heroPosition);
            GameManager.SetLastCheckpoint(heroPosition);
            
        }
    }
}
