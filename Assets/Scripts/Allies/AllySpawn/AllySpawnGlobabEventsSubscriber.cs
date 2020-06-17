public class AllySpawnGlobabEventsSubscriber : AllySpawnerComponet
{
	public void BecomeActiveCasarm()
	{
		var instance = GameInfoSingleton.Instance;
		instance.ActiveCasarm = this;
	}

	public void Spawn(AllyInfo allyInfo)
	{
		eventsProxy.OnSpawning.Invoke(allyInfo);
		var instance = GameInfoSingleton.Instance;
		instance.ActiveCasarm = null;
	}
}
