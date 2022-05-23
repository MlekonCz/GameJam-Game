using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class InputHandler : MonoBehaviour
    {
        [SerializeField] public float horizontalMovement;
        [SerializeField] public float verticalMovement;
        
        private PlayerControls _inputActions;
        private Vector2 _movementInput;

        public bool spaceInput;
        public bool jumpFlag;


        private void OnEnable()
        {
            if (_inputActions == null)
            {
                _inputActions = new PlayerControls();
                _inputActions.PlayerMovement.Movement.performed += OnMovementPerformed;
            }
        }

        private void OnMovementPerformed(InputAction.CallbackContext context)
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
        private void HandleJump(InputAction.CallbackContext context)
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
        
        public void OnDisable()
        {
            _inputActions.Disable();
        }
    }
}
