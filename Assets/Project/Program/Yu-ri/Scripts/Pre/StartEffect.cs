using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartEffect : MonoBehaviour
{
    public Material wipeCircle;
    float radius = 2.0f;
    const int forNum = 100;
    [SerializeField] GameObject title;
    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, wipeCircle);
    }
    private void Start()
    {
        wipeCircle.SetFloat("_Radius", radius);
    }
    private void Update()
    {
        
    }
    public void WipeCircle()
    {
        StartCoroutine("CorWipeCircle");
    }
    IEnumerator CorWipeCircle()
    {
        title.SetActive(false);
        for(int i = 0; i < forNum; i++)
        {
            radius -= 1.8f / forNum;
            wipeCircle.SetFloat("_Radius", radius);
            yield return new WaitForSeconds(0.9f / forNum);
        }
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < forNum; i++)
        {
            radius -= 0.2f / forNum;
            wipeCircle.SetFloat("_Radius", radius);
            yield return new WaitForSeconds(0.1f / forNum);
        }
        SceneManager.LoadScene("Stage1");
    }
}
