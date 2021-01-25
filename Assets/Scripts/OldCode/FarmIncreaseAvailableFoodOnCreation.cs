using UnityEngine;

public class FarmIncreaseAvailableFoodOnCreation : MonoBehaviour
{
	[SerializeField]
	int increaseCount = 2;

	private void Awake()
	{
		var instance = PlayerResources.Instance;
		instance.AddResources(0, increaseCount);
	}

	private void OnDestroy()
	{
		var instance = PlayerResources.Instance;
		if (!instance) return;
		instance.AddResources(0, -increaseCount);
	}
}
