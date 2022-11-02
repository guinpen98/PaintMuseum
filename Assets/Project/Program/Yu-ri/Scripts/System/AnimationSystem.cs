using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSystem : BaseSystem
{
    public override void SetEvent()
    {
        _gameState.playerEntity.SetAnimator += SetPlayerAnimator;
        foreach (DoorEntity doorEntity in _gameState.doorEntities) doorEntity.SetIsOpen += SetDoorAnimator;
    }
    public void SetPlayerAnimator()
    {
        if (_gameState.playerEntity.moveComponent.inputMove.x == 0 && _gameState.playerEntity.moveComponent.inputMove.y == 0) _gameState.playerEntity.animator.SetBool("IsMove", false);
        else _gameState.playerEntity.animator.SetBool("IsMove", true);
        if (_gameState.playerEntity.moveComponent.inputMove.x > 0)
        {
            _gameState.playerEntity.animator.SetFloat("X", 1f);
            _gameState.playerEntity.animator.SetFloat("Y", 0f);
        }
        else if (_gameState.playerEntity.moveComponent.inputMove.x < 0)
        {
            _gameState.playerEntity.animator.SetFloat("X", -1f);
            _gameState.playerEntity.animator.SetFloat("Y", 0f);
        }
        else if (_gameState.playerEntity.moveComponent.inputMove.y > 0)
        {
            _gameState.playerEntity.animator.SetFloat("X", 0f);
            _gameState.playerEntity.animator.SetFloat("Y", 1f);
        }
        else if (_gameState.playerEntity.moveComponent.inputMove.y < 0)
        {
            _gameState.playerEntity.animator.SetFloat("X", 0f);
            _gameState.playerEntity.animator.SetFloat("Y", -1f);

        }
    }
    public void SetDoorAnimator(DoorEntity doorEntity)
    {
        if (doorEntity.isOpen && !_gameState.isEKey) return;
        doorEntity.animator.SetBool("IsOpen", doorEntity.isOpen);
    }
}
