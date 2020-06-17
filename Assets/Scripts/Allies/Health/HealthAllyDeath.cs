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
		var instance = GameInfoSingleton.Instance;
		instance.OnAllyDeath?.Invoke(transform);
		Instantiate(zombifiedVersion, transform.position, transform.rotation);
		instance.OnAllyDeath?.Invoke(transform);
		Destroy(gameObject);
	}
}
