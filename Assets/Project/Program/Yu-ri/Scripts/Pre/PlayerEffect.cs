using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffect : MonoBehaviour
{
    [SerializeField] GameObject effect;
    private Vector3 mousePosition;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePosition = Input.mousePosition;
            mousePosition.z = 5f;
            Instantiate(effect, Camera.main.ScreenToWorldPoint(mousePosition), Quaternion.identity);
        }
    }
}
