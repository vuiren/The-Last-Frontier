public abstract class ZombieSpawnerComponent : EventsProxyComponent<ZombieSpawnerEventsProxy>
{
	internal override void SubscribeToEvents()
	{
		base.SubscribeToEvents();
		var instance = GameInfoSingleton.Instance;
		instance.OnGameWinning += () => enabled = false;
	}
}
