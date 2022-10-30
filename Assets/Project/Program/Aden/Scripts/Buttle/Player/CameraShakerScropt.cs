using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraShakerScropt : GameManager 
{
    public void shake()
    {
        transform.DOShakePosition(1, 0.5f, 10,1,false,true);
    }
}
