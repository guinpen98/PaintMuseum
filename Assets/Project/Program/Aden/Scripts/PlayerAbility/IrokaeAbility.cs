using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IrokaeAbility : MonoBehaviour
{
    Camera mainCamera;
    GameObject obj;
    int iro_number = 0;
    [SerializeField] private GameObject Cursormanager;
    private string colorcode;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Alpha1))
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
            
        }*/

        //CursorManagerスクリプトからいまどの色になっているかを取ってきてcolorcode変数に代入
        colorcode = Cursormanager.GetComponent<CursorManager>().colorname;
        //筆の色の判別
        switch (colorcode)
        {
            case "Blue":
                iro_number = 3;
                break;
            case "Red":
                iro_number = 1;
                break;
            case "Yellow":
                iro_number = 4;
                break;
            case "Green":
                iro_number = 2;
                break;
            case "Pink":
                iro_number = 5;
                break;
            case "White":
                iro_number = 5;
                break;
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

