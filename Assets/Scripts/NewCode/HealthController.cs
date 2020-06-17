using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
	[SerializeField]
	int maxHealthCount = 3;

	[SerializeField]
	IntUnityEvent onHealthChanged;

	[SerializeField]
	UnityEvent onDeath;

	[SerializeField]
	int healthCount;

	private void Awake()
	{
		healthCount = maxHealthCount;
	}

	public void TakeDamage(int damageCount)
	{
		healthCount -= damageCount;
		onHealthChanged.Invoke(healthCount);
		if (healthCount <= 0)
			onDeath.Invoke();
	}

	public void TakeHeal(int healCount)
	{
		healthCount += healCount;
		onHealthChanged.Invoke(healthCount);
	}

	public bool HealingRequired() => healthCount < maxHealthCount;
}
