using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusUIChanger :  GameManager
{
    private bool is_open = false;

    [SerializeField] Image image;

    [SerializeField]
    private Sprite[] StatusUI = new Sprite[2];

    public void UIChange()
    {
        if (is_open == true)
        {
            image.sprite = StatusUI[0];
            is_open = false;
        }
        else if (is_open == false)
        {
            image.sprite = StatusUI[1];
            is_open = true;
        }
    }
}
