using System;
using UnityEngine;

namespace Enemy
{
    public class SlimeMovement : MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;
        private Collider2D _collider2D;

    
        [SerializeField] private Transform leftWallCheck;
        [SerializeField] private Transform rightWallCheck;
        [SerializeField] private Transform groundCheck;
        [SerializeField] private LayerMask groundLayer;

        private float _lastTimeJumped;
        private float _jumpForce;

        private bool _touchedLeftWall = false;
        private bool _touchedRightWall = false;
        private bool _isGrounded;
        private bool _isGoingRight;
    
        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _collider2D = GetComponent<Collider2D>();
        }

        private void Start()
        {
            _jumpForce = GetComponent<EnemyStats>().enemyDefinition.jumpForce;
        }

        private void Update()
        {
            GroundCheck();
            WallCheck();
            HandleMovement();
            _lastTimeJumped += Time.deltaTime;
        }

        private void HandleMovement()
        {
            if (!_isGrounded || _lastTimeJumped < 3f){return;}

            if (_isGoingRight)
            {
                _rigidbody2D.velocity = new Vector2(_jumpForce - _jumpForce / 2, _jumpForce );
                _lastTimeJumped = 0;
            }
            else
            {
                _rigidbody2D.velocity = new Vector2(-_jumpForce + _jumpForce/2, _jumpForce);
                _lastTimeJumped = 0;
            }
       
        }

        private void GroundCheck()
        {
            _isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
            if (!_isGrounded)
            {
                _lastTimeJumped = 0;
            }
        }
        private void WallCheck()
        {
            _touchedRightWall = Physics2D.OverlapCircle(rightWallCheck.position, 0.2f, groundLayer);
            _touchedLeftWall = Physics2D.OverlapCircle(leftWallCheck.position, 0.2f, groundLayer);
            if (_touchedLeftWall)
            {
                _isGoingRight = true;
            }
            if (_touchedRightWall)
            {
                _isGoingRight = false;
            }
        }
    
    }
}
