using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SB : MonoBehaviour
{
    private float speed = 0.8f;
    [SerializeField]
    private TMPro.TMP_Text text;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {

        text.color= GetAlphaColor(text.color);
        
    }

    public Color GetAlphaColor(Color color)
    {
       
        time += Time.deltaTime * 5.0f * speed;
        color.a = Mathf.Sin(time);

        return color;
    }
}
