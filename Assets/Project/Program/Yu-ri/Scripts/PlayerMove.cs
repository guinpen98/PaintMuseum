using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] float speed = 3;

        [SerializeField] float jumpSpeed = 7;

        [SerializeField] float gravity = 15;

        [SerializeField] float fallSpeed = 10;

        [SerializeField] float initFallSpeed = 2;

        CharacterController characterController;

        Vector2 inputMove;
        float verticalVelocity;
        bool isGroundedPrev;

        Animator anima;

        public void OnJump(InputAction.CallbackContext context)
        {
            // ボタンが押された瞬間かつ着地している時だけ処理
            if (!context.performed || !characterController.isGrounded) return;

            // 鉛直上向きに速度を与える
            verticalVelocity = jumpSpeed;
        }
        public void OnMove(InputAction.CallbackContext context)
        {
            // 入力値を保持しておく
            inputMove = context.ReadValue<Vector2>();
            setAnima();
        }
        void setAnima()
        {
            if (inputMove.x == 0 && inputMove.y == 0) anima.SetFloat("Speed", 0f);
            else anima.SetFloat("Speed", 1f);
            if (inputMove.x != 1.0f && inputMove.x != -1.0f) return;
            Vector3 scale = transform.localScale;
            scale.x = inputMove.x;
            transform.localScale = scale;
        }

        private void Start()
        {
            characterController = GetComponent<CharacterController>();
            anima = GetComponent<Animator>();
        }

        private void Update()
        {
            Jump();
            Move();
        }
        void Jump()
        {
            bool isGrounded = characterController.isGrounded;
            anima.SetBool("IsGrounded", isGrounded);

            if (isGrounded && !isGroundedPrev)
            {
                // 着地する瞬間に落下の初速を指定しておく
                verticalVelocity = -initFallSpeed;
            }
            else if (!isGrounded)
            {
                // 空中にいるときは、下向きに重力加速度を与えて落下させる
                verticalVelocity -= gravity * Time.deltaTime;

                // 落下する速さ以上にならないように補正
                if (verticalVelocity < -fallSpeed)
                    verticalVelocity = -fallSpeed;
            }

            isGroundedPrev = isGrounded;
        }
        void Move()
        {
            // 操作入力と鉛直方向速度から、現在速度を計算
            var moveVelocity = new Vector3(
                inputMove.x * speed,
                verticalVelocity,
                inputMove.y * speed
            );
            // 現在フレームの移動量を移動速度から計算
            var moveDelta = moveVelocity * Time.deltaTime;

            // CharacterControllerに移動量を指定し、オブジェクトを動かす
            characterController.Move(moveDelta);
        }
    }
}