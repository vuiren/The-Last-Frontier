using UnityEngine;
using UnityEngine.Events;

public class OnGameWin : SingletonSubscriber
{
	[SerializeField]
	UnityEvent onGameWinEvents;

	internal override void SubscribeToEvents()
	{
		var instance = GameManager.Instance;

		instance.OnGameWinning += onGameWinEvents.Invoke;
	}

	internal override void UnSubscribeFromEvents()
	{
		var instance = GameManager.Instance;
		if (!instance) return;
		instance.OnGameWinning -= onGameWinEvents.Invoke;
	}
}
