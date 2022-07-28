using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour
{
    [Header("�ړ��̑���"), SerializeField]
    private float _speed = 3;

    private CharacterController _characterController;

    private Vector2 _inputMove;
    private float _verticalVelocity;

    Animator anima;

    public void OnMove(InputAction.CallbackContext context)
    {
        // ���͒l��ێ����Ă���
        _inputMove = context.ReadValue<Vector2>();
        setAnima();
    }
    void setAnima()
    {
        if (_inputMove.x == 0 && _inputMove.y == 0) anima.SetFloat("Speed", 0f);
        else anima.SetFloat("Speed", 1f);
        if (_inputMove.x != 1.0f && _inputMove.x != -1.0f) return;
        Vector3 scale = transform.localScale;
        scale.x = _inputMove.x;
        transform.localScale = scale;
    }

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        anima = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
    }
    void Move()
    {
        // ������͂Ɖ����������x����A���ݑ��x���v�Z
        var moveVelocity = new Vector3(
            _inputMove.x * _speed,
            _verticalVelocity,
            _inputMove.y * _speed
        );
        // ���݃t���[���̈ړ��ʂ��ړ����x����v�Z
        var moveDelta = moveVelocity * Time.deltaTime;

        // CharacterController�Ɉړ��ʂ��w�肵�A�I�u�W�F�N�g�𓮂���
        _characterController.Move(moveDelta);
    }
}
