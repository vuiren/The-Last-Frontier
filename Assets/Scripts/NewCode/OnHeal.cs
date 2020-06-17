using UnityEngine;

public class OnHeal : MonoBehaviour, IHealable
{
    [SerializeField]
    HealthController healthController;

    [SerializeField]
    IntUnityEvent onHeal;

    public void Heal(int healCount)
    {
        onHeal.Invoke(healCount);
    }

    public bool HealingRequired()
    {
        return healthController.HealingRequired();
    }
}
