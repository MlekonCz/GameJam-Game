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

        public event Action onFinishReached;

        public bool isInteracting;
        public bool isGrounded;
        public bool canClimb;
        private void Awake()
        {
            _inputHandler = GetComponent<InputHandler>();
            _animator = GetComponentInChildren<Animator>();
            _playerMovement = GetComponent<PlayerMovement>();
        }

        private void Update()
        {
            float delta = Time.deltaTime;

            isInteracting = _animator.GetBool("isInteracting");
            GroundCheck();
            _inputHandler.TickInput(delta);
            _playerMovement.TickInput(delta);
        }
        private void LateUpdate()
        {
            _inputHandler.jumpFlag = false;
        }
        private void GroundCheck()
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        }

        
        

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(TagManager.Finish))
            {
                onFinishReached?.Invoke();
            }
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(TagManager.Ladder))
            {
                canClimb = true;
            }
        }
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(TagManager.Ladder))
            {
                canClimb = false;
            }
        }
    }
}
