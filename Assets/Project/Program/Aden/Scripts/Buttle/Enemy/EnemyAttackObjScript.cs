using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackObjScript : GameManager
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == this.gameObject.tag)
        {
            Break();
        }
    }
    private void Break()
    {
        Destroy(this.gameObject);
    }
}
