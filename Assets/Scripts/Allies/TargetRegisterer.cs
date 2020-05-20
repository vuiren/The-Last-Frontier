using System;
using UnityEngine;

public class TargetRegisterer : MonoBehaviour, ITarget
{
	public Action<Transform> OnDestroyed { get; set; }

	public void OnDestroy()
	{
		OnDestroyed?.Invoke(transform);
	}

	private void OnDisable()
	{
		OnDestroyed?.Invoke(transform);
	}
}
