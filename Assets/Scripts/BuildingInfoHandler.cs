using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingInfoHandler : MonoBehaviour
{
	public Building.BuildingInfo buildingInfo;

	private void Awake()
	{
		GlobalDataTransfer.ConsumingFoodCount += buildingInfo.BuildingCost.FoodCost;
	}

	private void OnDestroy()
	{
		GlobalDataTransfer.ConsumingFoodCount -= buildingInfo.BuildingCost.FoodCost;
	}
}
