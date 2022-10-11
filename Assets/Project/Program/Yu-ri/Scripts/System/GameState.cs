using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

[System.Serializable]
public class GameState
{
    public PlayerEntity playerEntity;
    public WarpEntity[] warpEntities;
    public DoorEntity[] doorEntities;
    public GameObject camera2;

    public bool isEKey;

    public bool isFadeOut;
    public bool isFadeIn;
    public GameObject FadePanel;
    public bool isWarp;
    public Vector3 warpPosition;
}
