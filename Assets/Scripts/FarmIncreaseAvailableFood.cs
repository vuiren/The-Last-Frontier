using UnityEngine;

public class FarmIncreaseAvailableFood : MonoBehaviour
{
	[SerializeField]
	int increaseCount = 2;

	private void Awake()
	{
		GlobalDataTransfer.AvailableFoodAmount += increaseCount;
	}

	private void OnDisable()
	{
		GlobalDataTransfer.AvailableFoodAmount -= increaseCount;
	}
}
