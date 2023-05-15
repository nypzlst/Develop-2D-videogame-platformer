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


    public void Continue()
    {
        GameManager.SetStartMap();
        if (GameManager.GetMapIndex() >= 8 || GameManager.GetMapIndex() == 0)
        {
            button.interactable = false;
            
        }
        else
        {
                SceneManager.LoadScene("Loading");
        }
    }


}
