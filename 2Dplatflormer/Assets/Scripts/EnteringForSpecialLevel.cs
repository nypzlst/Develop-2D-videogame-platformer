using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnteringForSpecialLevel : MonoBehaviour
{
   
    SpriteRenderer spriteRenderer;
    private void Awake()
    {
        GameManager.SetSecretItem();
        GameManager.ReturnNum();
        Debug.Log(GameManager.ReturnNum());
        if(GameManager.ReturnNum() == 0)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }

    }
 
   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Hero"))
        {
           
                SceneManager.LoadScene(sceneBuildIndex:10);
                
            
        }
    }
   

}
