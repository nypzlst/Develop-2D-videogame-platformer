using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public Button button;

    // Start is called before the first frame update
    public void Play()
    {
        SceneManager.LoadScene("StartNewGame");
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Player quit");
    }

    bool isActive = false;

    private void Update()
    {
        GameManager.SetStartMap();
        if (GameManager.GetMapIndex() >= 7 || GameManager.GetMapIndex() == 0)
        {
            isActive = false;
            button.gameObject.SetActive(false);
        }
        else
        {
            isActive = true;
        }
    }


    public void Continue()
    {
        GameManager.SetStartMap();
        //if (GameManager.GetMapIndex() >= 6 || GameManager.GetMapIndex() == 0)
        //{
        //    button.interactable = false;
            
            
        //}
        //else
        //{
        //        SceneManager.LoadScene("Loading");
            
        //}
        if(isActive)
        {
            SceneManager.LoadScene("Loading");
        }
        else
        {
            button.interactable = false;
        }
    }


}
