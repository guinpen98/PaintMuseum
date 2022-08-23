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

        CharacterController _characterController;

        Vector2 inputMove;
        float verticalVelocity;
        bool isGroundedPrev;

        Animator _anima;

        public void OnJump(InputAction.CallbackContext context)
        {
            // �{�^���������ꂽ�u�Ԃ����n���Ă��鎞��������
            if (!context.performed || !_characterController.isGrounded) return;

            // ����������ɑ��x��^����
            verticalVelocity = jumpSpeed;
        }
        public void OnMove(InputAction.CallbackContext context)
        {
            // ���͒l��ێ����Ă���
            inputMove = context.ReadValue<Vector2>();
            setAnima();
        }
        void setAnima()
        {
            if (inputMove.x == 0 && inputMove.y == 0) _anima.SetBool("IsMove", false);
            else _anima.SetBool("IsMove", true);
            if (inputMove.x > 0)
            {
                _anima.SetFloat("X", 1f);
                _anima.SetFloat("Y", 0f);
            }
            else if (inputMove.x < 0)
            {
                _anima.SetFloat("X", -1f);
                _anima.SetFloat("Y", 0f);
            }
            else if (inputMove.y > 0)
            {
                _anima.SetFloat("X", 0f);
                _anima.SetFloat("Y", 1f);
            }
            else if(inputMove.y < 0)
            {
                _anima.SetFloat("X", 0f);
                _anima.SetFloat("Y", -1f);

            }
        }

        private void Start()
        {
            _characterController = GetComponent<CharacterController>();
            _anima = GetComponent<Animator>();
        }

        private void Update()
        {
            Jump();
            Move();
        }
        void Jump()
        {
            bool isGrounded = _characterController.isGrounded;
            //_anima.SetBool("IsGrounded", isGrounded);

            if (isGrounded && !isGroundedPrev)
            {
                // ���n����u�Ԃɗ����̏������w�肵�Ă���
                verticalVelocity = -initFallSpeed;
            }
            else if (!isGrounded)
            {
                // �󒆂ɂ���Ƃ��́A�������ɏd�͉����x��^���ė���������
                verticalVelocity -= gravity * Time.deltaTime;

                // �������鑬���ȏ�ɂȂ�Ȃ��悤�ɕ␳
                if (verticalVelocity < -fallSpeed)
                    verticalVelocity = -fallSpeed;
            }

            isGroundedPrev = isGrounded;
        }
        void Move()
        {
            // ������͂Ɖ����������x����A���ݑ��x���v�Z
            var moveVelocity = new Vector3(
                inputMove.x * speed,
                verticalVelocity,
                inputMove.y * speed
            );
            // ���݃t���[���̈ړ��ʂ��ړ����x����v�Z
            var moveDelta = moveVelocity * Time.deltaTime;

            // CharacterController�Ɉړ��ʂ��w�肵�A�I�u�W�F�N�g�𓮂���
            _characterController.Move(moveDelta);
        }
    }
}