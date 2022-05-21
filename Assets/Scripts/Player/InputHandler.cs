using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class InputHandler : MonoBehaviour
    {
        [SerializeField] public float horizontal;
        [SerializeField] public float moveAmount;

        private PlayerControls _inputActions;
        private Vector2 _movementInput;
        
        public bool sprintFlag;


        private void OnEnable()
        {
            if (_inputActions == null)
            {
                _inputActions = new PlayerControls();
                _inputActions.PlayerMovement.Movement.performed += OnMovementPerformed;
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
            horizontal = _movementInput.x;
            moveAmount = horizontal;
        }
        
        
        
        
        public void OnDisable()
        {
            _inputActions.Disable();
        }
    }
}
