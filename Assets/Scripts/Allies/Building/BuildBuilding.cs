using Sirenix.OdinInspector;
using UnityEngine;

namespace Building
{
	public class BuildBuilding : BuildingComponent
	{
		[ShowInInspector]
		BuildingInfo buildingInfo;

		Vector3 buildingPlace;

		internal override void SubscribeToEvents()
		{
			base.SubscribeToEvents();
			eventsProxy.OnReachingBuildingPlace += DoBuildBuilding;
			eventsProxy.OnBuildingToBuildSet += SetBuilding;
			eventsProxy.OnBuildingPlaceSetting += SetPlace;
		}

		private void SetBuilding(BuildingInfo obj)
		{
			buildingInfo = obj;
		}

		private void SetPlace(Vector3 obj)
		{
			buildingPlace = obj;
		}

		private void DoBuildBuilding()
		{
			var cost = buildingInfo.BuildingCost;
			if (cost.FoodCost + GlobalDataTransfer.ConsumingFoodCount > GlobalDataTransfer.AvailableFoodAmount || cost.MetalCost > GlobalDataTransfer.MetalCount) return;
			var building = Instantiate(buildingInfo.BuildingInstancePrefab, buildingPlace, new Quaternion());
			GlobalDataTransfer.MetalCount -= buildingInfo.BuildingCost.MetalCost;
			GlobalDataTransfer.OnCommandTypeChange?.Invoke(CommandsEnum.GoTo);
			eventsProxy.EndBuilding?.Invoke();
		}
	}
}