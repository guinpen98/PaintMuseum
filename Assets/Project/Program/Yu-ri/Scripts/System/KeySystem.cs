using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySystem : BaseSystem
{
    public override void SetEvent()
    {
        _gameState.keyEntity.getKey += GetKey;
    }
    void GetKey()
    {
        _gameState.key.gameObject.SetActive(false);
        _gameState.goal.SetActive(false);
    }
}
