using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalCameraMove : MonoBehaviour
{
    [SerializeField]
    private GameObject clearText;
    [SerializeField]
    private GameObject continuButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (transform.position.z >= 112.0f)
        {
            
            transform.position += new Vector3(0, 0, -1) * Time.deltaTime;
        }
        else
        {
            if (transform.position.y <= 219.0f)
                transform.position += new Vector3(0, 0.6f, 0) * Time.deltaTime;
            else
            {
                clearText.SetActive(true);
                continuButton.SetActive(true);
            }
                
        }
        
    }
}
