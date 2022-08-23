using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSlow : MonoBehaviour
{
    [SerializeField] float t = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0.1f;   
    }

    // Update is called once per frame
    void Update()
    {
        if (t <= 0)
        {
            origin();
        }
    }
    private void FixedUpdate()
    {
        t -= Time.deltaTime;
        
    }
    void origin()
    {
        Time.timeScale = 1;
        Destroy(this.gameObject);
    }
}
