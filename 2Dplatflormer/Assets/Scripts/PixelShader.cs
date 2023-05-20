using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
//[AddComponentMenu("Image Effects")]
public class PixelShader : MonoBehaviour
{

    //[Range(64.0f, 512.0f)] public float BlockCount = 128;

    //private void OnRenderImage(RenderTexture source, RenderTexture destination)
    //{
    //    float camera = Camera.main.aspect;
    //    Vector2 count = new Vector2(BlockCount, BlockCount/camera);
    //    Vector2 size = new Vector2 (1.0f/ count.x, 1.0f/ count.y);

    //    Material.
    //}

    public Shader pixelShader;  // ���������� ������

    private Material shaderMaterial;

    private void Start()
    {
        if (pixelShader == null)
        {
            Debug.LogError("Pixel shader is not assigned!");
            return;
        }

        // ������� �������� �� ������ ����������� �������
        shaderMaterial = new Material(pixelShader);
    }
    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (shaderMaterial == null)
        {
            // ���� �������� �� ������, ������ �������� �������� ����������� � ������� RenderTexture
            Graphics.Blit(source, destination);
            return;
        }

        // ��������� ���������� ������ � ��������� ����������� � ������� ��������� � ������� RenderTexture
        Graphics.Blit(source, destination, shaderMaterial);
    }
}
