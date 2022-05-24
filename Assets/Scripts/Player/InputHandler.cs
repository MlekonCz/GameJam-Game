using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class InputHandler : MonoBehaviour
    {
        [SerializeField] public float horizontalMovement;
        [SerializeField] public float verticalMovement;

        private PlayerManager _playerManager;
        private PlayerAttacker _playerAttacker;
        private PlayerControls _inputActions;
        private Vector2 _movementInput;

        public bool spaceInput;
        public bool jumpFlag;
        public bool attackInput;
        public bool defendInput;


        private void Awake()
        {
            _playerManager = GetComponent<PlayerManager>();
            _playerAttacker = GetComponent<PlayerAttacker>();
        }

        private void OnEnable()
        {
            if (_inputActions == null)
            {
                _inputActions = new PlayerControls();
                _inputActions.PlayerActions.Movement.performed += OnMovementPerformed;
            }
        }

        public void OnMovementPerformed(InputAction.CallbackContext context)
        {
            _movementInput = context.ReadValue<Vector2>();
        }


        public void TickInput(float delta)
        {
            MovementInput(delta);
        }

        private void MovementInput(float delta)
        {
            horizontalMovement = _movementInput.x;
            verticalMovement = _movementInput.y;
        }

        public void HandleJump(InputAction.CallbackContext context)
        {
            spaceInput = context.performed;
            if (spaceInput)
            {
                jumpFlag = true;
            }
            else
            {
                jumpFlag = false;
            }
        }

        public void HandleAttacking(InputAction.CallbackContext context)
        {
          
            attackInput = context.performed;
            Debug.Log(attackInput);
            if (_playerManager.isInteracting){return;}
            if (attackInput)
            {
                _playerAttacker.HandleAttacking();
            }
        }
        public void HandleDefending(InputAction.CallbackContext context)
        {
            defendInput = context.performed;
            if (_playerManager.isInteracting){return;}
            if (defendInput)
            {
                _playerAttacker.HandleDefending();
            }
        }

        public void OnDisable()
        {
            _inputActions.Disable();
            _inputActions.PlayerActions.Attack.performed -= HandleAttacking;
            _inputActions.PlayerActions.Defend.performed -= HandleDefending;
        }
    }
}