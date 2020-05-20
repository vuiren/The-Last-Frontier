using UnityEngine;

public abstract class CommandWorkerComponent : EventsProxyComponent<CommandWorkerEventsProxy>
{
	[SerializeField]
	bool stayEnabled = false;

	internal override void SubscribeToEvents()
	{
		base.SubscribeToEvents();
		eventsProxy.OnCommandEnd += () => enabled = stayEnabled;
	}
}
