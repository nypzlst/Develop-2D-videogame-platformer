using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingMenu : AbstractLoading
{


    public override void LoadingScene()
    {
        base.LoadingScene();
        if (timer <= 0)
        {
            GameManager.SetStartMap();
            SceneManager.LoadScene(GameManager.GetMapIndex());
            GameManager.SetStartPosition();
            transform.position = GameManager.GetLaskCheckpoint();
            Time.timeScale = 1f;   
        }
    }
}
