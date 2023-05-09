using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void Play()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Player quit");
    }


    public void Continue()
    {
        GameManager.SetStartMap();
        SceneManager.LoadScene(GameManager.GetMapIndex());
        GameManager.SetStartPosition();
        transform.position = GameManager.GetLaskCheckpoint();
    }


}
