using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageObject : MonoBehaviour, IEffectable
{
    bool isStop = false;
    Rigidbody rb;
    Vector3 force = new Vector3(0.0f, -1.0f, 0.0f);
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if (isStop) rb.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        else Move();
    }

    void Move()
    {
        rb.AddForce(force);
    }
    void SetIsStopFalse()
    {
        isStop = false;
    }
    public void Stop()
    {
        isStop = true;
        Invoke("SetIsStopFalse", 5.0f);
    }
}
