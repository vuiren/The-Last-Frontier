using UnityEngine;
using Building;
using UnityEngine.UI;
using Sirenix.OdinInspector;

public class BuildButtonInfo : MonoBehaviour
{
	[SerializeField]
	Image buildingImage;

	[SerializeField]
	Text buildingName;

	[SerializeField]
	Text buildingMetalCost;

	[SerializeField]
	Text buildingFoodCost;

	[ReadOnly]
	public BuildingInfo buildingInfo;

	public void SetupButton(BuildingInfo buildingInfo)
	{
		this.buildingInfo = buildingInfo;
		buildingImage.sprite = buildingInfo.BuildingSprite;
		buildingName.text = buildingInfo.BuildingName;
		buildingMetalCost.text = buildingInfo.BuildingCost.MetalCost.ToString();
		buildingFoodCost.text = buildingInfo.BuildingCost.FoodCost.ToString();
	}
}
