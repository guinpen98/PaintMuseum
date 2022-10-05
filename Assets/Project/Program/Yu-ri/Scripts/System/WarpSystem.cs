using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpSystem : BaseSystem
{
    public override void SetEvent()
    {
        foreach (WarpEntity warpEntity in _gameState.warpEntities) warpEntity.SetWarp += SetWarp;
        _gameEvent.Warp += Warp;
    }
    void Warp()
    {
        _gameState.playerEntity.transform.position = _gameState.warpPosition;
    }
    void SetWarp(Vector3 warpPosition)
    {
        _gameEvent.SetWarp.Invoke();
        _gameState.warpPosition = warpPosition;
    }
}
