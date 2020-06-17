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
			var instance = GameInfoSingleton.Instance;
			if (cost.FoodCost + instance.ConsumingFoodCount > instance.AvailableFoodAmount || cost.MetalCost > instance.MetalCount) return;
			var building = Instantiate(buildingInfo.BuildingInstancePrefab, buildingPlace, new Quaternion());
			instance.MetalCount -= buildingInfo.BuildingCost.MetalCost;
			instance.OnCommandTypeChange?.Invoke(CommandsEnum.GoTo);
			eventsProxy.EndBuilding?.Invoke();
		}
	}
}