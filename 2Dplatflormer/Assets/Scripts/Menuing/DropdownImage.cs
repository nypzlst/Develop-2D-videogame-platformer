using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownImage : MonoBehaviour
{
    public Dropdown dropdown;
    public Image image;

    public Sprite[] dropdownSprites;

    private void Start()
    {
        dropdown.onValueChanged.AddListener(OnDropdownValueChanged);
        OnDropdownValueChanged(dropdown.value);
    }

    private void OnDropdownValueChanged(int index)
    {
        if (index >= 0 && index < dropdownSprites.Length)
        {
            image.sprite = dropdownSprites[index];
        }
    }
}
