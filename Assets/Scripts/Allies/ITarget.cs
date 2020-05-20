using System;
using UnityEngine;

public interface ITarget
{
	Action<Transform> OnDestroyed { get; set; }
	void OnDestroy();
}
