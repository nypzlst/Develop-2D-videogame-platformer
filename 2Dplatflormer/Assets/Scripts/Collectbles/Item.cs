using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item: MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerSecretItem playerSecret = collision.GetComponent<PlayerSecretItem>();

        if(playerSecret!= null)
        {
            playerSecret.SecretItemCollected();
            gameObject.SetActive(false);
        }
    }

}
