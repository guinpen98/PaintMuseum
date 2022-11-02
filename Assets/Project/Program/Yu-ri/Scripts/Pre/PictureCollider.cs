using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureCollider : MonoBehaviour
{
    [SerializeField] GameObject stageText;
    [SerializeField] int stageNumber;
    [SerializeField] ExhibitionEvent exhibitionEvent;
    bool isTrigger = false;
    void Start()
    {
        stageText.SetActive(false);
        exhibitionEvent.GetEKey += LoadStage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            stageText.SetActive(true);
            isTrigger = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            stageText.SetActive(false);
            isTrigger = false;
        }
    }
    void LoadStage()
    {
        if (!isTrigger) return;
        exhibitionEvent.loadStage(stageNumber);
    }
}
