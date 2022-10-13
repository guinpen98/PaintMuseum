using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackObjGeneratorScript : GameManager
{
   [SerializeField] private  GameObject[] AttackObjPosition = new GameObject[3];
   [SerializeField] private GameObject AttackObj;
    protected override void IsAttackObj()
    {
        if (GameObject.Find("AttackObj(Clone)") == null)
        {
            AttackObjGene();
        }
    }
    protected override void AttackObjGene()
    { 
        int attack_obj_position = Random.Range(0, 3);
        Instantiate(AttackObj, AttackObjPosition[attack_obj_position].transform.position, Quaternion.identity);

    }
}
