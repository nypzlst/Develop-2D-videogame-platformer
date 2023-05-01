using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    TrailRenderer tr;

    [Header("Move")]

    public float moveSpeed = 1f;
    public Vector2 moveVector;
    public bool faceRight = true;// перевірка направлення персонажа
    private float moveX;

    [Header("Jump")]
    public int maxJump = 2;
    public float jumpForce = 5f;
    public int jumpCount =0;
    public float secondJumpMult = 0.75f;

    [Header("CheckGround")]
    public Transform GroundCheck;
    public float checkRadius = 0.5f;
    public LayerMask Ground;    
    private bool ground;

    [Header("Dash")]
    public int dashForce = 5000;
    private bool dashBlock = false;
  

  

    [Header("Coyote time")]
    public float coyoteTime = 0.2f;
    private float coyoteTimeCounter;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        tr = GetComponent<TrailRenderer>();
        checkRadius = GroundCheck.GetComponent<CircleCollider2D>().radius;
       
    }


    void Update()
    {
        Move();
        Reflect();
        Jump();
        OnGround();
        onDash();
        //WallJump();
      
    }

    private void Move()
    {
        moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);
        anim.SetFloat("Run", Mathf.Abs(moveX));

        
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            Physics2D.IgnoreLayerCollision(7, 8, true);
            Invoke("IgnoreLayerOff", 0.5f);
        }
       
    }

    void Reflect()
    {
        if ((moveX > 0 && !faceRight) || (moveX < 0 && faceRight))
        {
            transform.localScale *= new Vector2(-1, 1);
            faceRight = !faceRight;
        }

    }
    private void Jump()
    {
        anim.SetBool("IsJump", true);
        if (Input.GetButtonDown("Jump") &&  coyoteTimeCounter>0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
           // isWallJump = false;
           

        }
        //Второй прыжок, на текущий момент не нужен, возможно в дальнейшем пригодиться 
        //else if(Input.GetButtonDown("Jump") && ++jumpCount < maxJump && condition)
        //{
        //    rb.velocity = new Vector2(rb.velocity.x, jumpForce * secondJumpMult);
        //    jumpCount++;
        //    condition = false;
        //}

        if (ground)
        {
            jumpCount = 0;
            coyoteTimeCounter = coyoteTime;
            anim.SetBool("IsJump", false);
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }
    }

    void OnGround()
    {
        ground = Physics2D.OverlapCircle(GroundCheck.position, checkRadius, Ground);
    }

    private void onDash()
    {
       
        if (Input.GetKeyDown(KeyCode.LeftShift) && !dashBlock)
        {
            
            dashBlock = true;
            Invoke("dashLock", 2f);
            
            rb.velocity = new Vector2(0, 0);
            tr.emitting = true;
            if (!ground){
                anim.StopPlayback();
                anim.Play("AirDash");
            }
            else{
                anim.StopPlayback();
                anim.Play("Dash");
            }
            if (!faceRight)
            {
                rb.AddForce(Vector2.left * dashForce);
                anim.SetBool("IsDash", false);
            }
            else if (faceRight)
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

    void IgnoreLayerOff()
    {
        Physics2D.IgnoreLayerCollision(7, 8, false);
    }
}
