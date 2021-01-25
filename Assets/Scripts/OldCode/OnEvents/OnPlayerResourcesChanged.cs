using UnityEngine;

public class OnPlayerResourcesChanged : SingletonSubscriber
{
	[SerializeField] GameResourcesUnityEvent onPlayerResourcesChanged;

	internal void CallEvent(GameResources gameResources)
	{
		onPlayerResourcesChanged.Invoke(gameResources);
	}

	internal override void SubscribeToEvents()
	{
		var instance = PlayerResources.Instance;
		instance.OnGameResourcesChanged += CallEvent;
	}

	internal override void UnSubscribeFromEvents()
	{
		var instance = PlayerResources.Instance;
		if (!instance) return;
		instance.OnGameResourcesChanged -= CallEvent;
	}
}
