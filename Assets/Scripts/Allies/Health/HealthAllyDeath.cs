using UnityEngine;

public class HealthAllyDeath : HealthComponent
{
	[SerializeField]
	GameObject zombifiedVersion;

	internal override void SubscribeToEvents()
	{
		base.SubscribeToEvents();
		eventsProxy.OnDeath += SpawnZombifiedVersion;
	}

	private void SpawnZombifiedVersion()
	{
		GlobalDataTransfer.OnAllyDeath?.Invoke(transform);
		Instantiate(zombifiedVersion, transform.position, transform.rotation);
		GlobalDataTransfer.OnAllyDeath?.Invoke(transform);
		Destroy(gameObject);
	}
}
