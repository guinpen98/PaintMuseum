using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yellow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickEvent()
    {
        CursorManager cursorManager;
        GameObject obj = GameObject.Find("CursorManager");
        cursorManager = obj.GetComponent<CursorManager>();
        cursorManager.colorname = "Yellow";
        Debug.Log(cursorManager.colorname);
    }
}
