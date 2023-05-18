using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablerScripts : MonoBehaviour
{
    public string nameScripts ="";


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Airbone"))
        {
            GameObject.Find("Hero").GetComponent<AirboneEffect>().enabled= false;
        }
    }


}
