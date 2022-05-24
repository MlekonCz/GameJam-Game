using UnityEngine;

namespace Player
{
    public class AnimationHandler : MonoBehaviour
    {
        private Animator _animator;


        public void Initialize()
        {
            _animator = GetComponentInChildren<Animator>();
        }


        public void UpdateMovementAnimation(float horizontalMovement)
        {
           _animator.SetFloat("Speed",horizontalMovement,0.1f, Time.deltaTime);

           if (horizontalMovement > 0)
           {
               PlayTargetAnimation("Walking", false);
           }
           else if (horizontalMovement <0)
           {
               PlayTargetAnimation("Walking", false);
           }
           else
           {
               PlayTargetAnimation("Idle", false);
           }

        }

        public void PlayTargetAnimation(string targetAnimation, bool isInteracting)
        {
            _animator.SetBool("isInteracting", isInteracting);
            _animator.Play(targetAnimation);
        }


    }
}