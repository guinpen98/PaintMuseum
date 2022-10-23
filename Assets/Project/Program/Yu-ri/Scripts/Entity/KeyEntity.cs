using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class KeyEntity : MonoBehaviour
{
    public Action getKey;
    void Start()
    {
        
    }

    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            getKey.Invoke();
        }
    }
}
