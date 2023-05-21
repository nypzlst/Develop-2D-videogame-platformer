using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleImage : MonoBehaviour
{
    public Toggle toggle;
    public Image image;

    public Sprite imageOn;
    public Sprite imageOff;

    private void Start()
    {
        toggle.onValueChanged.AddListener(OnToggleValueChanged);
        OnToggleValueChanged(toggle.isOn);
    }

    private void OnToggleValueChanged(bool isOn)
    {
        if (isOn)
        {
            image.sprite = imageOn;
        }
        else
        {
            image.sprite = imageOff;
        }
    }
}
