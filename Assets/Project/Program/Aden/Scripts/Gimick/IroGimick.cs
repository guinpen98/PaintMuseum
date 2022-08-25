using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IroGimick : MonoBehaviour
{
    Rigidbody rb;
    Vector3 G;
    BoxCollider col;
    // Start is called before the first frame update
    void Start()
    {
        G = new Vector3(0, 9.8f, 0);
        rb = this.gameObject.GetComponent<Rigidbody>();
        col = this.gameObject.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.GetComponent<Renderer>().material.color == Color.red)
        {
            col.enabled = true;
            rb.useGravity = false;
            rb.AddForce(G, ForceMode.Acceleration);

        }
        if(this.gameObject.GetComponent<Renderer>().material.color == Color.green)
        {
            col.isTrigger = true;
        }
        if (this.gameObject.GetComponent<Renderer>().material.color == Color.blue)
        {
            
        }
        if (this.gameObject.GetComponent<Renderer>().material.color == Color.yellow)
        {
            
        }
        if (this.gameObject.GetComponent<Renderer>().material.color == Color.green)
        {
            
        }
    }
}
