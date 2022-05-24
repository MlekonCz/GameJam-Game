using System;
using UnityEngine;

namespace Player
{
    public class PlayerAttacker : MonoBehaviour
    {
        private AnimationHandler _animationHandler;
        private InputHandler _inputHandler;


        private void Awake()
        {
            _animationHandler = GetComponent<AnimationHandler>();
            _inputHandler = GetComponent<InputHandler>();
        }

        public void HandleAttacking()
        {
            _animationHandler.PlayTargetAnimation("Attack", true);
        }

        public void HandleDefending()
        {
            _animationHandler.PlayTargetAnimation("Defend", true);
        }
        
        
        
    }
}