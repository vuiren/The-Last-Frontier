using UnityEngine;

public class AllyInfoHolder : MonoBehaviour
{
	public AllyInfo allyInfo;

	private void Awake()
	{
		GlobalDataTransfer.ConsumingFoodCount += allyInfo.AllyCost.FoodCost;
	}

	private void OnDestroy()
	{
		GlobalDataTransfer.ConsumingFoodCount -= allyInfo.AllyCost.FoodCost;
	}
}
