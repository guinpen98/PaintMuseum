using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StatusMove : MonoBehaviour
{
    [SerializeField]
   private bool is_open = false;

    public void OnCliclStatus()
    {
        if (is_open == true)
        {
            transform.DOMoveY(160f, 0.5f).SetRelative(true).SetEase(Ease.OutCubic);
            is_open = false;
        }

        else if (is_open == false)
        {
            transform.DOMoveY(-160f, 0.5f).SetRelative(true).SetEase(Ease.OutCubic);
            is_open = true;
        }
    }

    
  

}
