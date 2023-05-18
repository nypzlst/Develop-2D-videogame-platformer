using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirFlowForce : MonoBehaviour
{

    public float fallForce = 10f; // Сила отталкивания вверх

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Air")) // Проверяем, что персонаж столкнулся с землей
        {
            float fallVelocity = rb.velocity.y; // Получаем скорость падения по вертикали

            if (fallVelocity < 0) // Если падение вниз
            {
                Vector2 upwardForce = new Vector2(0f, -fallVelocity * fallForce);
                rb.AddForce(upwardForce, ForceMode2D.Impulse); // Применяем силу отталкивания вверх
            }
        }
    }

}
