using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class WarpEntity : MonoBehaviour
{
    public Action<Vector3> SetWarp;
    public WarpComponent warpComponent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) SetWarp.Invoke(warpComponent.warpPosition);
    }
}
