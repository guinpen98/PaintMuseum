using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSystem : BaseSystem, IOnUpdateSystem
{
    public override void SetEvent()
    {
        _gameState.playerEntity.SetJump += SetJump;
        _gameState.playerEntity.SetMove += SetMove;
    }
    public void OnUpdate()
    {
        Jump();
        Move();
    }
    void Jump()
    {
        bool isGrounded = _gameState.playerEntity.characterController.isGrounded;
        //_anima.SetBool("IsGrounded", isGrounded);

        if (isGrounded && !_gameState.playerEntity.moveComponent.isGroundedPrev)
        {
            // 着地する瞬間に落下の初速を指定しておく
            _gameState.playerEntity.moveComponent.verticalVelocity = -_gameState.playerEntity.moveComponent.initFallSpeed;
        }
        else if (!isGrounded)
        {
            // 空中にいるときは、下向きに重力加速度を与えて落下させる
            _gameState.playerEntity.moveComponent.verticalVelocity -= _gameState.playerEntity.moveComponent.gravity * Time.deltaTime;

            // 落下する速さ以上にならないように補正
            if (_gameState.playerEntity.moveComponent.verticalVelocity < -_gameState.playerEntity.moveComponent.fallSpeed)
                _gameState.playerEntity.moveComponent.verticalVelocity = -_gameState.playerEntity.moveComponent.fallSpeed;
        }

        _gameState.playerEntity.moveComponent.isGroundedPrev = isGrounded;
    }
    void Move()
    {
        // 操作入力と鉛直方向速度から、現在速度を計算
        var moveVelocity = new Vector3(
            _gameState.playerEntity.moveComponent.inputMove.x * _gameState.playerEntity.moveComponent.speed,
            _gameState.playerEntity.moveComponent.verticalVelocity,
            _gameState.playerEntity.moveComponent.inputMove.y * _gameState.playerEntity.moveComponent.speed
        );
        // 現在フレームの移動量を移動速度から計算
        var moveDelta = moveVelocity * Time.deltaTime;
        // CharacterControllerに移動量を指定し、オブジェクトを動かす
        _gameState.playerEntity.characterController.Move(moveDelta);
    }
    void SetJump()
    {

        // 鉛直上向きに速度を与える
        //_gameState.playerEntity.moveComponent.verticalVelocity = _gameState.playerEntity.moveComponent.jumpSpeed;
    }
    void SetMove(Vector2 moveVec2)
    {
        // 入力値を保持しておく
        _gameState.playerEntity.moveComponent.inputMove = moveVec2;
    }
}
