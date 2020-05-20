using System;
using UnityEngine;

public class HealthKeeper : HealthComponent
{
	int maxHealthCount = 3;
	[SerializeField]
	int healthCount = 3;

	bool deathWasCalled;

	internal override void SubscribeToEvents()
	{
		base.SubscribeToEvents();
		eventsProxy.OnTakingDamage += UpdateHealth;
		eventsProxy.OnHeal += Heal;
	}

	private void Heal(int obj)
	{
		healthCount += obj;
		eventsProxy.RequiredHealing = healthCount < maxHealthCount;
		eventsProxy.OnHealthChanged?.Invoke(healthCount);
	}

	private void Start()
	{
		eventsProxy.OnHealthChanged?.Invoke(healthCount);
		maxHealthCount = healthCount;
	}

	private void UpdateHealth(int obj)
	{
		healthCount -= obj;
		eventsProxy.RequiredHealing = healthCount < maxHealthCount;
		eventsProxy.OnHealthChanged?.Invoke(healthCount);
		if (!deathWasCalled && healthCount <= 0)
		{
			deathWasCalled = true;
			eventsProxy.OnDeath?.Invoke();
		}
	}

	internal override void DisableComponent()
	{
	}

	internal override void EnableComponent()
	{
	}
}
