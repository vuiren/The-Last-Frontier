using UnityEngine;

public class DeathExpecter : WarriorComponent
{
	[SerializeField]
	int healthCountToDie = 0;

	protected override void SubscribeToEventsProxy()
	{
		eventsProxy.OnHealthChanged += CheckHP;
	}

	internal override void DisableComponent()
	{
		throw new System.NotImplementedException();
	}

	internal override void EnableComponent()
	{
		throw new System.NotImplementedException();
	}

	private void CheckHP(int healthCount)
	{
		if(healthCount<=healthCountToDie)
		{
			eventsProxy.OnDeath?.Invoke();
		}
	}
}
