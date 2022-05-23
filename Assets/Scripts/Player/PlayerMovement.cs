using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private InputHandler _inputHandler;
        private PlayerManager _playerManager;

        private Rigidbody2D _rigidBody2D;
        private Vector2 _moveDirection;
        private Vector2 _climbDirection;
        private Transform _myTransform;
        
        [SerializeField] private float gravityScale = 1.5f;
        [SerializeField] private float movementSpeed = 5f;
        [SerializeField] private float climbSpeed = 5f;
        [SerializeField] private float jumpingPower = 15f;

        private bool _isFacingRight;

        private void Awake()
        {
            _inputHandler = GetComponent<InputHandler>();
            _playerManager = GetComponent<PlayerManager>();
            _rigidBody2D = GetComponent<Rigidbody2D>();
            _myTransform = transform;
        }

        public void TickInput(float delta)
        {
            HandleMovement(delta);
            HandleJumping();
            HandleClimbing();
            HandleFalling();
        }
        #region Movement
        private void HandleMovement(float delta)
        {
            _moveDirection = _myTransform.right * _inputHandler.horizontalMovement;
            _moveDirection.Normalize();

            _rigidBody2D.velocity = new Vector2(_moveDirection.x * movementSpeed, _rigidBody2D.velocity.y);

            if (!_isFacingRight && _moveDirection.x > 0f)
            {
                FlipSprite();
            }
            else if (_isFacingRight && _moveDirection.x < 0f)
            {
                FlipSprite();
            }
        }

        private void HandleClimbing()
        {
            if (_playerManager.canClimb )
            {
                _rigidBody2D.gravityScale = 0f;
            }
            else
            {
                _rigidBody2D.gravityScale = gravityScale;
                return;
            }
            
            _climbDirection = transform.up * _inputHandler.verticalMovement;
            _climbDirection.Normalize();

            _rigidBody2D.velocity = new Vector2(_rigidBody2D.velocity.x, _climbDirection.y * climbSpeed);
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
        private void HandleJumping()
        {
            if (_inputHandler.jumpFlag && _playerManager.isGrounded)
            { 
                _rigidBody2D.velocity = new Vector2(_rigidBody2D.velocity.x, jumpingPower);
            }
            else if (_inputHandler.jumpFlag == false && _rigidBody2D.velocity.y > 0f)
            {
                Vector2 velocity = new Vector2(_rigidBody2D.velocity.x, _rigidBody2D.velocity.y * 0.5f);
                _rigidBody2D.velocity = velocity;
            }
        }

        private void HandleFalling()
        {
            if (_playerManager.canClimb){return;}
            
            if (_rigidBody2D.velocity.y < 0f)
            {
                _rigidBody2D.gravityScale = gravityScale * 2;
            }
            else
            {
                _rigidBody2D.gravityScale = gravityScale;
            }
        }
        #endregion

      
        
    }
}
