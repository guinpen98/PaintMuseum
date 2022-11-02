using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISceneManager : MonoBehaviour
{
    [SerializeField] public GameObject UIPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            Debug.Log("a");
        }
    }


}
