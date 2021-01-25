using UnityEngine;

public class SetAnimationToPlay : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    public void PlayAnimation(string animationName)
    {
        animator.Play(animationName);
    }
}
