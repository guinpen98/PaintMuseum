using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DrowLine : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private int positioncount =0;
    private Camera maincamera;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.useWorldSpace = false;
        positioncount = 0;
        maincamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = maincamera.transform.position + maincamera.transform.forward * 10;
        transform.rotation = maincamera.transform.rotation;

        if (Input.GetMouseButton(0))
        {
            lineRenderer.startColor = Color.yellow;
            lineRenderer.endColor = Color.blue;
            Vector3 pos = Input.mousePosition;
            pos.z = 4.0f;
           
            pos = maincamera.ScreenToWorldPoint(pos);

            pos = transform.InverseTransformPoint(pos);

            positioncount++;
            lineRenderer.positionCount = positioncount;
            lineRenderer.SetPosition(positioncount - 1, pos);

                
        }
        if (Input.GetMouseButtonUp(0))
        {
            positioncount = 0;
        }
    }
}
