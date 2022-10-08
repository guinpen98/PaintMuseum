using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHPScript : GameManager
{
    [SerializeField] private float max_hp;
    [SerializeField] private float hp;
    [SerializeField] private Image back;
    [SerializeField] private Image front;
    private void DestroyEnemy()
    {
        Destroy(this.gameObject);
    }
    private void HPSlider()
    {
        Debug.Log(hp/max_hp);
        front.fillAmount = hp / max_hp;
    }

    private void OnTriggerEnter(Collider other)
    {
        
    
    
        if(other.gameObject.tag == "SmallAttack")
        {
            Debug.Log("small");
            hp--;
            HPSlider();
            if (hp <= 0)
            {
                DestroyEnemy();
            }
        }
        else if(other.gameObject.tag == "BigWholeAttack")
        {
            HPSlider();
            hp -= 3;
            if (hp <= 0)
            {
                DestroyEnemy();
            }
        }
        else if (other.gameObject.tag == "BigSingleAttack")
        {
            HPSlider();
            hp -= 6;
            if (hp <= 0)
            {
                DestroyEnemy();
            }
        }
    }

}
