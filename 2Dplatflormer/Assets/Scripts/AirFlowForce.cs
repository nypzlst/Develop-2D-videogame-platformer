using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirFlowForce : MonoBehaviour
{

    public float fallForce = 10f; // ���� ������������ �����

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Air")) // ���������, ��� �������� ���������� � ������
        {
            float fallVelocity = rb.velocity.y; // �������� �������� ������� �� ���������

            if (fallVelocity < 0) // ���� ������� ����
            {
                Vector2 upwardForce = new Vector2(0f, -fallVelocity * fallForce);
                rb.AddForce(upwardForce, ForceMode2D.Impulse); // ��������� ���� ������������ �����
            }
        }
    }

}
