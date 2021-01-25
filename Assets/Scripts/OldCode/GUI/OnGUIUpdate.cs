using UnityEngine;
using UnityEngine.Events;

public class OnGUIUpdate : SingletonSubscriber
{
	[SerializeField]
	UnityEvent onGUIUpdate;

	internal override void SubscribeToEvents()
	{
		var instance = GUIManager.Instance;
		instance.OnGUIUpdate += CallEvent;
	}

	private void CallEvent()
	{
		onGUIUpdate.Invoke();
	}

	internal override void UnSubscribeFromEvents()
	{
		var instance = GUIManager.Instance;
		if (!instance) return;
		instance.OnGUIUpdate -= CallEvent;
	}
}