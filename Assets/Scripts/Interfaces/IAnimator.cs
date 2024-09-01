using UnityEngine;

namespace Interfaces
{
    public interface IAnimator
    {
        public Animator Animator { get; set; }

        public void SetBool(string name, bool value);

        public void SetFloat(string name, float value);

        public void SetInteger(string name, int value);

        public void SetTrigger(string name);

        public void PlayAnimationByHash(int hash);
    }
}
