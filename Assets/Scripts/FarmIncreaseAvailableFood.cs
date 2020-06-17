using UnityEngine;

public class FarmIncreaseAvailableFood : MonoBehaviour
{
	[SerializeField]
	int increaseCount = 2;

	private void Awake()
	{
		var instance = GameInfoSingleton.Instance;
		instance.AvailableFoodAmount += increaseCount;
	}

	private void OnDisable()
	{
		var instance = GameInfoSingleton.Instance;
		if (!instance) return;
		instance.AvailableFoodAmount -= increaseCount;
	}
}
