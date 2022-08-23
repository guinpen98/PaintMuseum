using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj_Get : MonoBehaviour
{
    int get;
    string get_obj;
    GameObject Hold_obj;
    Vector3 this_obj;
    // Start is called before the first frame update
    void Start()
    {
        get = PlayerPrefs.GetInt("get", 0);
        if(get == 1)
        {
            ins();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
         if(other.gameObject.tag == "CanGet")
        {
            if (get == 0)
            {
                get_obj = other.gameObject.name;
                PlayerPrefs.GetString("GetObj", get_obj);
                PlayerPrefs.SetString("GetObj", get_obj);
                PlayerPrefs.Save();
                PlayerPrefs.SetInt("get", 1);
                PlayerPrefs.Save();
                other.gameObject.GetComponent<MeshRenderer>().enabled = false;
                other.gameObject.GetComponent<BoxCollider>().enabled = false;
              }
            Debug.Log(get_obj);
            Destroy(this.gameObject);
        }

    }
    void ins()
    {
        this_obj = this.transform.position;
       
        GameObject.Find(PlayerPrefs.GetString("GetObj", "i")).transform.position = this_obj;
        GameObject.Find(PlayerPrefs.GetString("GetObj", "i")).GetComponent<MeshRenderer>().enabled = true;
        GameObject.Find(PlayerPrefs.GetString("GetObj", "i")).GetComponent<BoxCollider>().enabled = true;
        PlayerPrefs.SetInt("get", 0);
        PlayerPrefs.Save();
        Destroy(this.gameObject);
    }
}
