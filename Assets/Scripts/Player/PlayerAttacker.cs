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

        private void HandleAttacking()
        {
            _animationHandler.PlayTargetAnimation("Attack", true);
        }

        private void HandleDefending()
        {
            _animationHandler.PlayTargetAnimation("Defend", true);
        }
        
        
        
    }
}