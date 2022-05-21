using System;
using UnityEngine;

namespace Player
{
    public class PlayerManager : MonoBehaviour
    {
        private InputHandler _inputHandler;
        private Animator _animator;
        private PlayerMovement _playerMovement;
        
        public bool isSprinting;
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
            
            _inputHandler.TickInput(delta);
            _playerMovement.HandleMovement(delta);
        }

        
        private void LateUpdate()
        {
            _inputHandler.sprintFlag = false;
        }
    }
}
