using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerEntity : MonoBehaviour
{
    public CharacterController characterController;
    public Animator animator;
    public MoveComponent moveComponent;
    public Action SetJump;
    public Action<Vector2> SetMove;
    public Action SetAnimator;

    public void OnJump(InputAction.CallbackContext context)
    {
        // �{�^���������ꂽ�u�Ԃ����n���Ă��鎞��������
        if (!context.performed || !characterController.isGrounded) return;

        SetJump.Invoke();
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        SetMove.Invoke(context.ReadValue<Vector2>());
        SetAnimator.Invoke();
    }
}
