using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour
{
    [Header("移動の速さ"), SerializeField]
    private float _speed = 3;

    private CharacterController _characterController;

    private Vector2 _inputMove;
    private float _verticalVelocity;

    Animator anima;

    public void OnMove(InputAction.CallbackContext context)
    {
        // 入力値を保持しておく
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
        // 操作入力と鉛直方向速度から、現在速度を計算
        var moveVelocity = new Vector3(
            _inputMove.x * _speed,
            _verticalVelocity,
            _inputMove.y * _speed
        );
        // 現在フレームの移動量を移動速度から計算
        var moveDelta = moveVelocity * Time.deltaTime;

        // CharacterControllerに移動量を指定し、オブジェクトを動かす
        _characterController.Move(moveDelta);
    }
}
