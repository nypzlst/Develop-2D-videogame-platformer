using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Death : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        if (HeroDeath)
        {
            RestartLvl();
            HeroDeath= false;
        }
        
    }
    void RestartLvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        HeroDeath= false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DeathColl"))
        {
            OnDeath(2f,"Death");
        }else if (collision.gameObject.CompareTag("DeathCollSecond"))
        {
            OnDeath(1f,"Hit");
        }
    }

    void OnDeath(float timeAnimation,string animationName)
    {
        Invoke("RestartLvl", timeAnimation);
        HeroDeath = true;
        anim.StopPlayback();
        anim.Play(animationName);
    }

    private bool HeroDeath = false;
}
