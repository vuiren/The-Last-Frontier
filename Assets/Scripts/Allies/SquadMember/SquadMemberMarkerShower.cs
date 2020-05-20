using UnityEngine;

public class SquadMemberMarkerShower : EventsProxyComponent<SquadMemberEventsProxy>
{
	[SerializeField]
	GameObject marker;

	internal override void SubscribeToEvents()
	{
		base.SubscribeToEvents();
		eventsProxy.OnMemberChoosed += ShowMarker;
		eventsProxy.OnMemberUnchoosed += HideMarker;
	}

	private void HideMarker()
	{
		marker.SetActive(false);
	}

	private void ShowMarker()
	{
		marker.SetActive(true);
	}
}
