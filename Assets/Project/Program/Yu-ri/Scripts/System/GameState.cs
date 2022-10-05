using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

[System.Serializable]
public class GameState
{
    public PlayerEntity playerEntity;
    public WarpEntity[] warpEntities;

    public bool isFadeOut;
    public bool isFadeIn;
    public GameObject FadePanel;
    public Vector3 warpPosition;
}
