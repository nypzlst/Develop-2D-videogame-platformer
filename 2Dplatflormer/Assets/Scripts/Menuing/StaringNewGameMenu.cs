using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class StaringNewGameMenu : AbstractLoading
{

    public override void LoadingScene()
    {
        base.LoadingScene();
        Debug.Log(timer);
        if (timer <= 0)
        {
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene(1);
        }

    }
  
}
