using Interfaces;


namespace Character
{
    public class AnimatorController : IAnimator
    {
        public UnityEngine.Animator Animator { get; set; }

        public void SetFloat(string name, float value)
        {
            Animator.SetFloat(name, value);
        }

        public void SetBool(string name, bool value)
        {
            Animator.SetBool(name, value);
        }

        public void SetInteger(string name, int value)
        {
            Animator.SetInteger(name, value);
        }

        public void SetTrigger(string name)
        {
            Animator.SetTrigger(name);
        }

        public void PlayAnimationByHash(int hash)
        {
            Animator.Play(hash);
        }
    }
}
