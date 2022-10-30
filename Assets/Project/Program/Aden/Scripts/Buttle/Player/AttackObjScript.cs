using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.UI;
public class AttackObjScript :GameManager
{
   [SerializeField] private Material[] AttackMaterial = new Material[3];
    private Vector3 enemy_position;
    private Vector3 after_attack_position;
    [SerializeField]
    private Material material;
 
    


    protected override void AttackRay()
    {
      
        if (Input.GetMouseButton(0))
        {
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float distance = 1000.0f;
            RaycastHit hit_info;
            bool is_hit = Physics.Raycast(ray, out hit_info, distance);
            Debug.Log(is_hit);
            if (is_hit)
            {
                if (hit_info.collider.tag == "AttackObj")
                {
                    OnClick();
                }
            }
        }
    }
    public void OnClick()
    {
        this.gameObject.tag = "SmallAttack";
        Debug.Log("ok");
        int AttackColorNumber;
        AttackColorNumber = Random.Range(0, 3);
        this.GetComponent<MeshRenderer>().material = AttackMaterial[AttackColorNumber];
        material = gameObject.GetComponent<Material>();

        enemy_position = GameObject.FindGameObjectWithTag("Enemy").transform.position;
        after_attack_position = (enemy_position - transform.position) * 0.1f;
        transform.DOMove(enemy_position, 1).SetEase(Ease.InQuart);
        var attack_seqence = DOTween.Sequence();
        attack_seqence.AppendInterval(1)
            .Append(transform.DOMove(after_attack_position, 1)).SetRelative(true)
            .Join(material.DOFade(0,1))
            .OnComplete(() => Destroy(this.gameObject));
    }


}
