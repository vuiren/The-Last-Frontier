using UnityEngine;

public class AllyInfoHolder : MonoBehaviour
{
	public AllyInfo allyInfo;

	private void Awake()
	{
		var instance = GameInfoSingleton.Instance;
		instance.ConsumingFoodCount += allyInfo.AllyCost.FoodCost;
	}

	private void OnDestroy()
	{
		var instance = GameInfoSingleton.Instance;
		instance.ConsumingFoodCount -= allyInfo.AllyCost.FoodCost;
	}
}
