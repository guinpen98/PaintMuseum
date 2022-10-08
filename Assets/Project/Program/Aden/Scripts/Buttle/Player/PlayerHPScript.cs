using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPScript : GameManager
{
    [SerializeField] private Image[] Heart = new Image[3];
    int PlayerHP = 3;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "EnemyAttackBlue")
        {
            PlayerHP--;
            HPCount();
        }
        else if (other.gameObject.tag == "EnemyAttackRed")
        {
            PlayerHP--;
            HPCount();
        }
        else if (other.gameObject.tag == "EnemyAttackGreen")
        {
            PlayerHP--;
            HPCount();
        }
    }
    private void HPCount()
    {
        if (PlayerHP < 3)
        {
            Heart[PlayerHP].fillAmount = 0;
        }
        else if(PlayerHP <= 0)
        {
            Death();
        }
    }
    private void Death()
    {

    }
}
