using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSecretItem : MonoBehaviour
{
    public int NumberOfSecretItem = 0;


    public void SecretItemCollected()
    {
        NumberOfSecretItem++;
        GameManager.AddSecretItem(NumberOfSecretItem);
        Debug.Log($"secret : {GameManager.ReturnNum()}");
    }
}

