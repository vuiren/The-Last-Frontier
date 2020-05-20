using Sirenix.OdinInspector;
using UnityEngine;

public abstract class EventsProxyComponent<T> : MonoBehaviour where T : Component
{
	[ReadOnly]
	[ShowInInspector]
	protected T eventsProxy;

	protected void Awake()
	{
		GetEventsProxy();
		SubscribeToEvents();
	}

	protected void OnEnable() => EnableComponent();

	internal virtual void EnableComponent() { }

	protected void OnDisable() => DisableComponent();

	internal virtual void DisableComponent() { }

	internal virtual void SubscribeToEvents() { }

	private void GetEventsProxy()
	{
		eventsProxy = GetComponent<T>();
		if (eventsProxy == null)
		{
			eventsProxy = gameObject.AddComponent<T>();
		}
	}
}