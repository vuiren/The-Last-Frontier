using UnityEngine;

public enum AnimationStates { Idle, Walking, Shooting }
public class ChangeAllyAnimation : MonoBehaviour
{
    [SerializeField]
    NPCInfoHolder NPCInfoHolder;

    [SerializeField]
    Animator animator;

    AnimationStates CurrentAnimationState { get; set; }

    // Update is called once per frame
    void Update()
    {
        var newState = GetCurrentAnimationState();
        if (newState == CurrentAnimationState) return;

        CurrentAnimationState = newState;
        switch(CurrentAnimationState)
        {
            case AnimationStates.Idle:
                animator.Play("Idle");
                break;
            case AnimationStates.Shooting:
                animator.Play("Shooting");
                break;
            case AnimationStates.Walking:
                animator.Play("Walking");
                break;
        }
    }

    AnimationStates GetCurrentAnimationState()
    {
        var target = NPCInfoHolder.AttackTarget;
        var rb = NPCInfoHolder.RigidBody;
        if (target)
            return AnimationStates.Shooting;

        if (!Mathf.Approximately(rb.velocity.x, 0))
            return AnimationStates.Walking;

        return AnimationStates.Idle;
    }
}