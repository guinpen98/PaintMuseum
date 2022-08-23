using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IrokaeAbility : MonoBehaviour
{
    Camera mainCamera;
    GameObject obj;
    int iro_number = 0;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            iro_number = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            iro_number = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            iro_number = 3;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            iro_number = 4;
            
        }
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 0.5f, false);

            if (Physics.Raycast(ray, out hit, 100))
            {
                obj = hit.collider.gameObject;
                

                if (obj.tag == "irokae")
                {

                    switch (iro_number) {
                        case 1:
                            obj.GetComponent<Renderer>().material.color = Color.red;
                            break;
                        case 2:
                            obj.GetComponent<Renderer>().material.color = Color.green;
                            break;
                        case 3:
                            obj.GetComponent<Renderer>().material.color = Color.blue;
                            break;
                        case 4:
                            obj.GetComponent<Renderer>().material.color = Color.yellow;
                            break;

                    }
                }
                }
            }
        }


    }

