using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAttackScript : GameManager
{
    [SerializeField] private float _time;
    [SerializeField] private float AttackTime;
    [SerializeField] private GameObject[] EnemyAttackObj = new GameObject[3];
    [SerializeField] private Image TimeGage;



    protected override void TimeCount()
    {
        float resetTime = Time.deltaTime;
        _time -= Time.deltaTime;
        TimeGage.fillAmount = 1 - _time / AttackTime;
        if (_time <= 0)
        {
            isTimer = false;

            EnemyAttack(resetTime);
            
        }
    }
    void EnemyAttack(float resetTime)
    {
        ReSetTime(resetTime);
        int EnemyAttackNumber;
        EnemyAttackNumber = Random.Range(0, 3);
        Instantiate(EnemyAttackObj[EnemyAttackNumber], this.transform.position = new Vector3(-1,0,0), Quaternion.identity);
    }
    void ReSetTime(float resetTime)
    {
        _time = AttackTime + resetTime;
        
    }
}
