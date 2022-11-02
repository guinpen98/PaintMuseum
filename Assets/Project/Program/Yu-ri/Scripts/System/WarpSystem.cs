using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpSystem : BaseSystem
{
    public override void SetEvent()
    {
        foreach (WarpEntity warpEntity in _gameState.warpEntities) warpEntity.SetWarp += SetWarp;
        _gameEvent.Warp += Warp;
        _gameEvent.FinishWarp += FinishWarp;
    }
    void Warp()
    {
        _gameState.playerEntity.transform.position = _gameState.warpPosition;
        bool isCamera2 = _gameState.warpPosition.x > 180;
        _gameState.camera2.SetActive(isCamera2);
    }
    void SetWarp(Vector3 warpPosition)
    {
        if (_gameState.isWarp) return;
        _gameState.isWarp = true;
        _gameEvent.SetWarp.Invoke();
        _gameState.warpPosition = warpPosition;
    }
    void FinishWarp()
    {
        _gameState.isWarp = false;
    }
}
