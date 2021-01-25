using System;
using UnityEngine;

public abstract class SingletonSubscriber: MonoBehaviour
{
	protected void OnEnable()
	{
		SubscribeToEvents();
	}

	protected void OnDisable()
	{
		UnSubscribeFromEvents();
	}

	internal abstract void UnSubscribeFromEvents();
	internal abstract void SubscribeToEvents();
}