using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UseShift : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public Canvas canvas;
    private void Start()
    {
       textMeshPro = gameObject.AddComponent<TextMeshProUGUI>();
        canvas = gameObject.AddComponent<Canvas>();
        textMeshPro.enabled = false;
        canvas.enabled = false;
    }

  

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Hero"))
        {
            textMeshPro.enabled = true;
            canvas.enabled = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        textMeshPro.enabled = false;
        canvas.enabled = false;
    }

}
