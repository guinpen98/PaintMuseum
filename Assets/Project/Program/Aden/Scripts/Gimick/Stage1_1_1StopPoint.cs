using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1_1_1StopPoint : MonoBehaviour
{
    Animator anime;
    // Start is called before the first frame update
    void Start()
    {
        anime = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Stop")
        {
            anime.enabled = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Stop")
        {
            anime.enabled = true;
        }
    }
}
