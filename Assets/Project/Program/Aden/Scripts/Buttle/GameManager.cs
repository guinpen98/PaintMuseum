using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public bool isTimer = true; 
    
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        

    }

    // Update is called once per frame
    void Update()
    {
        if(isTimer == true) TimeCount();
        IsAttackObj();
        AttackRay();
        
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
    void Is_Timer()
    {
        if (isTimer == false)
        {
            isTimer = true;
        }
    }
}
