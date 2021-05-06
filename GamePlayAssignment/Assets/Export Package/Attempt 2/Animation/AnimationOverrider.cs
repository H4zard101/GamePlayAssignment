using UnityEngine;

namespace Attempt_2.Animation
{
    public class AnimationOverrider : MonoBehaviour
    {
        private Animator animator;

        private void OnEnable()
        {
            animator = GetComponent<Animator>();
        }

        public void SetAniamtions(AnimatorOverrideController overrideController)
        {
            animator.runtimeAnimatorController = overrideController;
        }
    }
}