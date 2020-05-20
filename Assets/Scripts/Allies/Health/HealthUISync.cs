using UnityEngine;
using UnityEngine.UI;

public class HealthUISync : HealthComponent
{
	[SerializeField]
	Text text;

	internal override void SubscribeToEvents()
	{
		base.SubscribeToEvents();
		eventsProxy.OnHealthChanged += SyncCheck;
	}

	private void SyncCheck(int obj)
	{
		text.text = obj.ToString();
	}

	internal override void DisableComponent()
	{
	}

	internal override void EnableComponent()
	{
	}
}
