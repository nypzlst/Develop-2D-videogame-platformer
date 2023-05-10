using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
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
        SceneManager.LoadScene("Loading");
    }


}
