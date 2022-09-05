using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostEffect : MonoBehaviour
{
    [SerializeField] ExhibitionEvent exhibitionEvent;
    public Material wipeCircle;
    float radius = 2.0f;
    const int forNum = 100;
    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, wipeCircle);
    }
    private void Start()
    {
        exhibitionEvent.loadStage += WipeCircle;
        wipeCircle.SetFloat("_Radius", radius);
    }
    private void Update()
    {
        
    }
    void WipeCircle(int stageNumber)
    {
        StartCoroutine("CorWipeCircle");
    }
    IEnumerator CorWipeCircle()
    {
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
    }
}
