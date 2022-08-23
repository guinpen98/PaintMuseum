using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExhibitionEvent : MonoBehaviour
{
    public Action GetEKey; 
    public Action<int> loadStage;
    int tmpSceneNumber;
    string[] sceneName = { "Aden" };
    void Start()
    {
        loadStage += LoadScene;
    }

    void Update()
    {
        
    }
    void Load()
    {
        SceneManager.LoadScene(sceneName[tmpSceneNumber]);
    }
    void LoadScene(int sceneNumber)
    {
        tmpSceneNumber = sceneNumber;
        Invoke("Load", 3.0f);
    }
}
