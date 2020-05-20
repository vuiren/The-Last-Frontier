using Sirenix.OdinInspector;
using UnityEngine;

public abstract class AttackingComponent : EventsProxyComponent<AttackingEventsProxy>
{
	[SerializeField]
	bool alwaysEnabled;

	internal override void SubscribeToEvents()
	{
		base.SubscribeToEvents();
		eventsProxy.OnClosestTargetUpdate += (x) => enabled = true;
		eventsProxy.OnEnemyGone += () => enabled = alwaysEnabled;
	}
}