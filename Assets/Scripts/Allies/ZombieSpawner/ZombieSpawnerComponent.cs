public abstract class ZombieSpawnerComponent : EventsProxyComponent<ZombieSpawnerEventsProxy>
{
	internal override void SubscribeToEvents()
	{
		base.SubscribeToEvents();
		GlobalDataTransfer.OnGameWinning += () => enabled = false;
	}
}
