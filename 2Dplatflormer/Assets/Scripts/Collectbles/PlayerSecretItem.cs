using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSecretItem : MonoBehaviour
{
     int NumberOfSecretItem = 0;
    int Count;
    

    public void SecretItemCollected()
    {
        NumberOfSecretItem++;
        Count = NumberOfSecretItem;
        GameManager.AddSecretItem(Count);
        Debug.Log($"secret : {GameManager.ReturnNum()}");
    }
}

