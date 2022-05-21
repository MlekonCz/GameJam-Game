using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private InputHandler _inputHandler;
        private PlayerManager _playerManager;

        public Rigidbody2D rigidBody2D;
        public Vector2 moveDirection;
        public Transform myTransform;

        [SerializeField] private Transform groundCheck;
        [SerializeField] private LayerMask groundLayer;
        
        [SerializeField] private float movementSpeed = 5f;
        [SerializeField] private float sprintSpeed = 8f;
        [SerializeField] private float jumpingPower = 15f;

        private bool _isFacingRight;

        private void Awake()
        {
            _inputHandler = GetComponent<InputHandler>();
            _playerManager = GetComponent<PlayerManager>();
            rigidBody2D = GetComponent<Rigidbody2D>();
            myTransform = transform;
        }


        public void HandleMovement(float delta)
        {
            moveDirection = myTransform.right * _inputHandler.horizontal;
            moveDirection.Normalize();

            float speed = movementSpeed;

            if (_inputHandler.sprintFlag && _inputHandler.moveAmount >0.5f)
            {
                speed = sprintSpeed;
                _playerManager.isSprinting = true;
                moveDirection *= speed;
            }
            else
            {
                _playerManager.isSprinting = false;
                moveDirection *= speed;
            }

            rigidBody2D.velocity = new Vector2(moveDirection.x, rigidBody2D.velocity.y);

            if (!_isFacingRight && moveDirection.x > 0f)
            {
                Flip();
            }
            else if (_isFacingRight && moveDirection.x < 0f)
            {
                Flip();
            }
            
        }

        public void Jump(InputAction.CallbackContext context)
        {
            if (context.performed && IsGrounded())
            {
                rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, jumpingPower);
            }

            if (context.canceled && rigidBody2D.velocity.y > 0f)
            {
                rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, rigidBody2D.velocity.y * 0.5f);
            }
        }
        private bool IsGrounded()
        {
            return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        }

        private void Flip()
        {
            _isFacingRight = !_isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
        
        
        
        
        
    }
}
