using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuiteGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EndGame()
    {
        //if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
        

        //Application.Quit();//ゲームプレイ終了

    }
}
