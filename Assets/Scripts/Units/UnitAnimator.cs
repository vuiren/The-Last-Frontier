using UnityEngine;

namespace Units
{
    public class UnitAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        public void PlayAnimation(string animationName)
        {
            _animator.Play(animationName);
        }
    }
}