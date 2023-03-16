using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Invoke("NextState", 5f);
            // �������� �������� � �������� � ������ ����� ������ ������
            Debug.Log("Code 1");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        CancelInvoke("NextState");
        Debug.Log("Code 2");
    }


    void NextState()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}