using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
     public float climbingSpeed = 5f;
     private bool isClimbing = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hero"))
        {
            float verticalInput = Input.GetAxis("Vertical");

            if (verticalInput != 0f) 
            {
                isClimbing = true;
                Rigidbody2D playerRigidbody = collision.GetComponent<Rigidbody2D>();

                
                playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, verticalInput * climbingSpeed);
            }
            else
            {
                isClimbing = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hero"))
        {
            isClimbing = false;
        }
    }



}
