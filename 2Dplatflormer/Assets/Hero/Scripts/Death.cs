using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Death : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField] GameObject startPosition;

    private void Awake()
    {
        GameManager.SetStartMap();
        if(GameManager.GetMapIndex() != SceneManager.GetActiveScene().buildIndex)
        {
            Transform startTransform = startPosition.transform;
            transform.position = new Vector2(startTransform.position.x, startTransform.position.y);
        }
        else
        {
            GameManager.SetStartPosition();
            transform.position = GameManager.GetLaskCheckpoint();
        }
    }

    void Start()
    {
       
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        if (HeroDeath)
        {
            RestartLvl();
            HeroDeath = false;
        }
        
    }
    void RestartLvl()
    {
        GameManager.SetStartMap();
        SceneManager.LoadScene(GameManager.GetMapIndex());  
        HeroDeath = false;
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
        rb.bodyType = RigidbodyType2D.Static;
        HeroDeath = true;
        anim.StopPlayback();
        anim.Play(animationName);
       
    }
    public bool HeroDeath = false;
}
