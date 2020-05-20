public class CommandBuildCommand : CommandWorkerComponent
{
	BuildingEventsProxy buildingEventsProxy;

	private void Start()
	{
	}

	internal override void SubscribeToEvents()
	{
		base.SubscribeToEvents();
		eventsProxy.OnBuildCommand += StartBuilding;
	}

	private void StartBuilding(Command obj)
	{
		buildingEventsProxy = GetComponent<BuildingEventsProxy>();
		buildingEventsProxy.OnBuildingToBuildSet?.Invoke(obj.commandBuildingValue);
		buildingEventsProxy.OnBuildingPlaceSetting?.Invoke(obj.commandVectorValue);
	}
}
