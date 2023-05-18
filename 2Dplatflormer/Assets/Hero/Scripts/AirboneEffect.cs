using System.Collections;
using UnityEngine;


public class AirboneEffect : MonoBehaviour
{
    private Rigidbody2D rb;
    private Movement move;
    public float airSpeed = 2f;
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        move = GetComponent<Movement>();
    }

    void Update()
    {
        if (!move.ground)
        {
            rb.velocity = new Vector2(rb.velocity.x, -airSpeed);
        }
    }
}
