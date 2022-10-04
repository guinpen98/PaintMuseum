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
        // ƒ{ƒ^ƒ“‚ª‰Ÿ‚³‚ê‚½uŠÔ‚©‚Â’…’n‚µ‚Ä‚¢‚é‚¾‚¯ˆ—
        if (!context.performed || !characterController.isGrounded) return;

        SetJump.Invoke();
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        SetMove.Invoke(context.ReadValue<Vector2>());
        SetAnimator.Invoke();
    }
}
