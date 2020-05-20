using UnityEngine;

public class HealthStarter : MonoBehaviour
{
	private void Start()
	{
		var comms = GetComponents<HealthComponent>();
		foreach (var e in comms)
			e.enabled = true;
	}
}
