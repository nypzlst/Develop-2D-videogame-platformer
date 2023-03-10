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

    [Header("Wall Jump")]
    public float wallJumpTime = 0.2f;
    public float slideSpeed = 0.3f;
    public float wallDistance = 0.5f;
    public float wallJumpForce = 7f;
    bool isWallSliding = false;
    RaycastHit2D WallCheckingHit;
    float jumpTime;
    private bool isWallJump;

    [Header("Arround Jump")]
    public float xAxis;
    public float yAxis;
    public float dashSpeed;
    private Vector2 dashDir;

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
        WallJump();
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
        if (Input.GetButtonDown("Jump") && (coyoteTimeCounter>0 || isWallJump))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isWallJump = false;


        }
        else if(Input.GetButtonDown("Jump") && ++jumpCount < maxJump )
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce * secondJumpMult);
            jumpCount++;
        }

        if (ground)
        {
            jumpCount = 0;
            coyoteTimeCounter = coyoteTime;
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

            xAxis = Input.GetAxisRaw("Horizontal");
            yAxis = Input.GetAxisRaw("Vertical");
            dashDir = new Vector2(xAxis, yAxis).normalized;
            if (!faceRight && dashDir == new Vector2(-1,0))
            {
                rb.AddForce(Vector2.left * dashForce);
            }
            else if (!faceRight)
            {
                rb.velocity = dashDir * dashSpeed;
            }
            else if (faceRight && dashDir == new Vector2(1, 0))
            {
                rb.AddForce(Vector2.right * dashForce);
            }
            else if (faceRight)
            {
                rb.velocity = dashDir * dashSpeed;
            }
            
        }
    }

    void dashLock()
    {
        dashBlock = false;
        tr.emitting = false;
    }


    private void WallJump()
    {
        if (faceRight)
        {
            WallCheckingHit = Physics2D.Raycast(transform.position, new Vector2(wallDistance, 0), wallDistance, Ground);
        }
        else
        {
            WallCheckingHit = Physics2D.Raycast(transform.position, new Vector2(-wallDistance, 0), wallDistance, Ground);
        }


        if (WallCheckingHit && !ground && moveX !=0)
        {
            isWallSliding = true;
           // jumpTime = Time.time + wallJumpTime;
        }
        else if (jumpTime< Time.time)
        {
            isWallSliding = false;
        }

        if (isWallSliding)
        { 
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, slideSpeed, float.MaxValue));
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            isWallJump = true;
        }
    }

    void IgnoreLayerOff()
    {
        Physics2D.IgnoreLayerCollision(7, 8, false);
    }
}
