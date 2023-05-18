using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashMove : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    TrailRenderer tr;
    Movement move;


    [Header("Dash")]
    public int dashForce = 5000;
    private bool dashBlock = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        tr = GetComponent<TrailRenderer>();
        move = gameObject.GetComponent<Movement>();
    }

    void Update()
    {
        onDash();
    }

    private void onDash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !dashBlock)
        {

            dashBlock = true;
            Invoke("dashLock", 2f);

            rb.velocity = new Vector2(0, 0);
            tr.emitting = true;
            if (!move.ground)
            {
                anim.StopPlayback();
                anim.Play("AirDash");
            }
            else
            {
                anim.StopPlayback();
                anim.Play("Dash");
            }
            if (!move.faceRight)
            {
                rb.AddForce(Vector2.left * dashForce);
                anim.SetBool("IsDash", false);
            }
            else if (move.faceRight)
            {
                rb.AddForce(Vector2.right * dashForce);
                anim.SetBool("IsDash", false);
            }
        }
    }

    void dashLock()
    {
        dashBlock = false;
        tr.emitting = false;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DashOn"))
        {
            this.GetComponent<DashMove>().enabled = true;
        }
    }
}
