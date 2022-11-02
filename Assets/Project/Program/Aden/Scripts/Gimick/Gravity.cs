using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    [SerializeField]
    private Vector3 G;
    private Rigidbody rb;
    bool G_button=true;
    [SerializeField]
    private float GravityTime = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        G = new Vector3(0, 9.8f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "G_gimmick")
        {
            rb = other.gameObject.GetComponent<Rigidbody>();
            G_button = false;
        }
    }
    private void FixedUpdate()
    {

        if (G_button == false)
        {
            rb.useGravity = false;
            rb.AddForce(G, ForceMode.Acceleration);
            GravityTime -= Time.deltaTime;
            if (GravityTime <= 0)
            {
                rb.useGravity = true;
                G_button = true;
            }
        }
        
    }
}
