using UnityEngine;

namespace Core
{
    public class ResetAnimationBoo : StateMachineBehaviour
    {
        public string targetBool;
        public bool status;
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.SetBool(targetBool, status);
        }
    }
}
