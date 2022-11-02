using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class DoorEntity : MonoBehaviour
{
    public Action<DoorEntity> SetIsOpen;
    public Animator animator;
    public bool isOpen;
    private void OnTriggerStay(Collider other)
    {
        if (animator.GetBool("IsOpen")) return;
        if (other.gameObject.CompareTag("Player"))
        {
            isOpen = true;
            SetIsOpen.Invoke(this);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isOpen = false;
            SetIsOpen.Invoke(this);
        }
    }
}
