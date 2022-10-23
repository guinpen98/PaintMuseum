using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AttackObjMoverScript : GameManager
{
    private bool is_Move = true;

    [SerializeField]
    Material _material;

    protected override void IsAttackObj()
    {
        if(gameObject.tag == "SmallAttack" && is_Move == true)
        {
            is_Move = false;
            Vector3 target = GameObject.Find("TargetEnemy").transform.position;
            transform.DOMove(target, 1f).SetEase(Ease.InQuart).OnComplete(() => _material.DOColor(new Color(255, 255, 255, 0), 1f)).OnComplete(() => Destroy(this.gameObject));
        }
        else
        {
            return;
        }
    }
}
