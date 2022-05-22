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
        
        [SerializeField] private float movementSpeed = 5f;
        [SerializeField] private float jumpingPower = 15f;

        private bool _isFacingRight;

        private void Awake()
        {
            _inputHandler = GetComponent<InputHandler>();
            _playerManager = GetComponent<PlayerManager>();
            rigidBody2D = GetComponent<Rigidbody2D>();
            myTransform = transform;
        }

        #region Movement
        public void HandleMovement(float delta)
        {
            moveDirection = myTransform.right * _inputHandler.moveAmount;
            moveDirection.Normalize();

            float speed = movementSpeed;
            
            rigidBody2D.velocity = new Vector2(moveDirection.x * speed, rigidBody2D.velocity.y);

            if (!_isFacingRight && moveDirection.x > 0f)
            {
                FlipSprite();
            }
            else if (_isFacingRight && moveDirection.x < 0f)
            {
                FlipSprite();
            }
        }
        private void FlipSprite()
        {
            _isFacingRight = !_isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
        #endregion
        #region Jumping
        public void HandleJumping()
        {
            if (_inputHandler.jumpFlag && _playerManager.isGrounded)
            {
                rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, jumpingPower);
            }
            if (_inputHandler.jumpFlag == false && rigidBody2D.velocity.y > 0f)
            {
                Vector2 velocity = new Vector2(rigidBody2D.velocity.x, rigidBody2D.velocity.y * 0.5f);
                rigidBody2D.velocity = velocity;
            }
        }
        #endregion

      
        
    }
}
