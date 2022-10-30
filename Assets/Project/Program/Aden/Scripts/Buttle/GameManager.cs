using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    
    
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    
    }

    // Update is called once per frame
    void Update()
    {
        TimeCount();
        IsAttackObj();
        AttackRay();
        defenceObj();
    }

    protected virtual void AttackRay()
    {
        //->  AttackObjScript.cs
    }
    protected virtual void Attack()
    {
        //->AttackObjGeneratorScript.cs
    }
    protected virtual void IsAttackObj()
    {
        //->AttackObjGeneratorScript.cs
    }
    protected virtual void AttackObjGene()
    {
        //->AttackObjGeneratorScript.cs
    }
    protected virtual void TimeCount()
    {
        //->EnemyAttackScript.cs
    }
    protected virtual void defenceObj()
    {
        //->Defence.cs
    }
}
