public class CommandBuild : CommandWorkerComponent
{
	internal override void SubscribeToEvents()
	{
		base.SubscribeToEvents();
		eventsProxy.OnBuildCommand += StartBuildingSequence;
	}

	private void StartBuildingSequence(Command obj)
	{
		var buildEvents = GetComponent<BuildingEventsProxy>();
		buildEvents.OnBuildingToBuildSet?.Invoke(obj.commandBuildingValue);
		buildEvents.OnBuildingPlaceSetting?.Invoke(obj.commandVectorValue);
	}
}
