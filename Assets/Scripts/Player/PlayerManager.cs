using System;
using UnityEngine;

namespace Player
{
    public class PlayerManager : MonoBehaviour
    {
        private InputHandler _inputHandler;
        private Animator _animator;
        private PlayerMovement _playerMovement;
        
        [SerializeField] private Transform groundCheck;
        [SerializeField] private LayerMask groundLayer;
        
        public bool isGrounded;
        
        private void Awake()
        {
            _inputHandler = GetComponent<InputHandler>();
            _animator = GetComponent<Animator>();
            _playerMovement = GetComponent<PlayerMovement>();
        }

        private void Update()
        {
            float delta = Time.deltaTime;
            
            GroundCheck();
            _inputHandler.TickInput(delta);
            _playerMovement.HandleMovement(delta);
            _playerMovement.HandleJumping();
        }

        private void GroundCheck()
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        }
    }
}
