using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    Vector2 heroPosition;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hero"))
        {
            heroPosition= collision.transform.position;
            int index = SceneManager.GetActiveScene().buildIndex;
            Debug.Log(heroPosition);
            Debug.Log(index);
            GameManager.SetLastCheckpoint(heroPosition);
            GameManager.SetMapIndex(index);
        }
    }
}
