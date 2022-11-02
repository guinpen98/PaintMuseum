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
            // ���n����u�Ԃɗ����̏������w�肵�Ă���
            _gameState.playerEntity.moveComponent.verticalVelocity = -_gameState.playerEntity.moveComponent.initFallSpeed;
        }
        else if (!isGrounded)
        {
            // �󒆂ɂ���Ƃ��́A�������ɏd�͉����x��^���ė���������
            _gameState.playerEntity.moveComponent.verticalVelocity -= _gameState.playerEntity.moveComponent.gravity * Time.deltaTime;

            // �������鑬���ȏ�ɂȂ�Ȃ��悤�ɕ␳
            if (_gameState.playerEntity.moveComponent.verticalVelocity < -_gameState.playerEntity.moveComponent.fallSpeed)
                _gameState.playerEntity.moveComponent.verticalVelocity = -_gameState.playerEntity.moveComponent.fallSpeed;
        }

        _gameState.playerEntity.moveComponent.isGroundedPrev = isGrounded;
    }
    void Move()
    {
        // ������͂Ɖ����������x����A���ݑ��x���v�Z
        var moveVelocity = new Vector3(
            _gameState.playerEntity.moveComponent.inputMove.x * _gameState.playerEntity.moveComponent.speed,
            _gameState.playerEntity.moveComponent.verticalVelocity,
            _gameState.playerEntity.moveComponent.inputMove.y * _gameState.playerEntity.moveComponent.speed
        );
        // ���݃t���[���̈ړ��ʂ��ړ����x����v�Z
        var moveDelta = moveVelocity * Time.deltaTime;
        // CharacterController�Ɉړ��ʂ��w�肵�A�I�u�W�F�N�g�𓮂���
        _gameState.playerEntity.characterController.Move(moveDelta);
    }
    void SetJump()
    {

        // ����������ɑ��x��^����
        //_gameState.playerEntity.moveComponent.verticalVelocity = _gameState.playerEntity.moveComponent.jumpSpeed;
    }
    void SetMove(Vector2 moveVec2)
    {
        // ���͒l��ێ����Ă���
        _gameState.playerEntity.moveComponent.inputMove = moveVec2;
    }
}
