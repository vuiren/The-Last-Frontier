namespace Building
{
	public abstract class BuildingComponent : EventsProxyComponent<BuildingEventsProxy>
	{
		internal override void SubscribeToEvents()
		{
			base.SubscribeToEvents();
			eventsProxy.OnBuildingPlaceSetting += (x) => enabled = true;
			eventsProxy.OnBuildingToBuildSet += (x) => enabled = true;
			eventsProxy.OnReachingBuildingPlace += () => enabled = false;
			eventsProxy.EndBuilding += () => enabled = false;
		}
	}
}
