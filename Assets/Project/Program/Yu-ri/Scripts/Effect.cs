using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Effect : MonoBehaviour
{
    public abstract void giveEffect(IEffectable effectable);
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Effectable")
        {
            giveEffect(collision.gameObject.GetComponent<IEffectable>());
        }
    }
}
