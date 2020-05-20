public class AllySpawnGlobabEventsSubscriber : AllySpawnerComponet
{
	internal override void SubscribeToEvents()
	{
		base.SubscribeToEvents();
		GlobalDataTransfer.OnUIModeChange += (UIModesEnum x) =>
		{
			if(x != UIModesEnum.BuildUI)
			{
				GlobalDataTransfer.ActiveCasarm = null;
			}
		};
	}

	public void BecomeActiveCasarm()
	{
		GlobalDataTransfer.ActiveCasarm = this;
	}

	public void Spawn(AllyInfo allyInfo)
	{
		eventsProxy.OnSpawning.Invoke(allyInfo);
		GlobalDataTransfer.ActiveCasarm = null;
	}
}
