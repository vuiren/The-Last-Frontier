using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingInfoHandler : MonoBehaviour
{
	public Building.BuildingInfo buildingInfo;

	private void Awake()
	{
		var instance = GameInfoSingleton.Instance;
		instance.ConsumingFoodCount += buildingInfo.BuildingCost.FoodCost;
	}

	private void OnDestroy()
	{
		var instance = GameInfoSingleton.Instance;
		if (!instance) return;
		instance.ConsumingFoodCount -= buildingInfo.BuildingCost.FoodCost;
	}
}
