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
    public bool ground;

   
    [Header("Coyote time")]
    public float coyoteTime = 0.2f;
    private float coyoteTimeCounter;

    [Header("Trampline")]
    public float launchForce = 5f;


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
        }

        if (ground)
        {
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

    void IgnoreLayerOff()
    {
        Physics2D.IgnoreLayerCollision(7, 8, false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trampoline"))
        {
            rb.velocity = Vector2.up * launchForce;
        }
    }

}
