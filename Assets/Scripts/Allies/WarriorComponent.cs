using Sirenix.OdinInspector;
using UnityEngine;

public abstract class WarriorComponent : EventsProxyComponent<WarriorEventsProxy>
{

	public void InitializeComponent()
	{
	//	GetAlliesComponents();
	}

	protected virtual void SubscribeToEventsProxy() { }
}
