using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public GameObject pauseMenu;
    public  bool isPause =false;

    
    void Start()
    {
        pauseMenu.SetActive(false);
    }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPause)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPause= true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPause= false;
    }
}
