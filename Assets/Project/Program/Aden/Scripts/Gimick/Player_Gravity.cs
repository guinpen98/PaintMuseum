using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Gravity : MonoBehaviour
{
    [SerializeField]
    private Vector3 Player_trans;
    [SerializeField]
    private Vector3 This_trans;

    private float Acce_x;
    private float Acce_y;
    private Vector3 Acce;
    bool G_button = true;
    [SerializeField]
    private float GravityTime = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        This_trans = this.gameObject.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        Player_trans = GameObject.Find("UnityChan").transform.position;
        Acce_x = (This_trans.x - Player_trans.x)* Time.deltaTime;
        Acce_y = (This_trans.y - Player_trans.y) * Time.deltaTime;
        GameObject.Find("UnityChan").transform.position += new Vector3(Acce_x * 1f , Acce_y * 1f  , 0);
    }
    
    private void FixedUpdate()
    {
        if (G_button == true)
        {

            
            GravityTime -= Time.deltaTime;
            
            if (GravityTime <= 0)
            {
               
               // G_button = false;
            }
        }
        

    }
}
