using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : BaseSystem, IOnUpdateSystem
{
    public void OnUpdate()
    {
        _gameState.isEKey = Input.GetKey(KeyCode.E);
    }
}
