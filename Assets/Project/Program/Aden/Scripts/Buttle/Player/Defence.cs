using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Defence : GameManager
{
    bool check = true;

    protected override void defenceObj()
    {
        if (Input.GetKeyDown(KeyCode.Space) && check == true)
        {
            check = false;
            var Deffence_seqence = DOTween.Sequence();
            Deffence_seqence
                .Append(transform.DOMoveY(5, 2.5f)).SetEase(Ease.OutQuint).SetRelative(true)
                .Append(transform.DOMoveY(-5, 2.5f)).SetEase(Ease.OutCirc).SetRelative(true)
                .AppendInterval(2)
                .OnComplete(() => check = true);
        }
    }

}
