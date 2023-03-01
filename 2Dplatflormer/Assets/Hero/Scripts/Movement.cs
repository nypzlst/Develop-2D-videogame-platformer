using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    TrailRenderer tr;
    public float moveX;
    public float moveSpeed = 1f;
    public Vector2 moveVector;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        tr = GetComponent<TrailRenderer>();
        checkRadius = GroundCheck.GetComponent<CircleCollider2D>().radius;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Reflect();
        Jump();
        OnGround();
        onDash();
    }


    private void Move()
    {
        moveX  = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);
        anim.SetFloat("Run", Mathf.Abs(moveX));
    }
    public bool faceRight = true;
    void Reflect()
    {
        if ((moveX > 0 && !faceRight) || (moveX < 0 && faceRight))
        {
            transform.localScale *= new Vector2(-1, 1);
            faceRight = !faceRight;
        }
    }





    private int jumpCount =0;
    public int maxJump = 2;
    public float jumpForce = 5f;

    private void Jump()
    {

        if(Input.GetButtonDown("Jump") && (ground || (++jumpCount < maxJump)))
        {
            //rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        if (ground) { jumpCount=0; }
    }

    private bool ground;
    public Transform GroundCheck;
    public float checkRadius = 0.5f;
    public LayerMask Ground;

    void OnGround()
    {
        ground = Physics2D.OverlapCircle(GroundCheck.position, checkRadius, Ground);
    }

    public int dashForce = 5000;

    private void onDash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !dashBlock)
        {
            dashBlock = true;
            Invoke("dashLock", 0.1f);
            rb.velocity = new Vector2(0,0);
            tr.emitting= true;
            if(!faceRight)
            {
                rb.AddForce(Vector2.left * dashForce);

            }
            else
            {
                rb.AddForce(Vector2.right * dashForce);
                
            }
        }
    }

    private bool dashBlock = false;

    void dashLock()
    {
        dashBlock = false;
        tr.emitting = false;
    }
}
