using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractLoading : MonoBehaviour
{
    public float delay = 5f;
    public float timer;
    


    void Start()
    {
        timer = delay;
    }

    void Update()
    {
        LoadingScene();
    }

    public virtual void LoadingScene()
    {
        timer -= Time.time;
    }
}
