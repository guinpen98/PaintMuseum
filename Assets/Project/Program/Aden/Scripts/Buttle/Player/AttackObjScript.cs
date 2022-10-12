using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AttackObjScript :GameManager
{
   [SerializeField] private Material[] AttackMaterial = new Material[3];

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
                else if(hit_info.collider.tag == "DefenceObj")
                {

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
        
    }
}
