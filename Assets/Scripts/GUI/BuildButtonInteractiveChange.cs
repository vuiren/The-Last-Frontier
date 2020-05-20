using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

public class BuildButtonInteractiveChange : MonoBehaviour
{
	[SerializeField]
	Button button;

	[SerializeField]
	BuildButtonInfo buttonInfo;

	private void Awake()
	{
		GlobalDataTransfer.OnMetalCountChanged += CheckForMetalIfActive;
		GlobalDataTransfer.OnConsumingFoodCountChanged += CheckForMetalIfActive;
		CheckForMetalIfActive(GlobalDataTransfer.MetalCount);
	}

	private void CheckForMetalIfActive(int metalCount)
	{
		var buttonInfo = this.buttonInfo.buildingInfo.BuildingCost;
		bool foodCheck = (buttonInfo.FoodCost + GlobalDataTransfer.ConsumingFoodCount <= GlobalDataTransfer.AvailableFoodAmount);
		bool metalCheck = buttonInfo.MetalCost <= GlobalDataTransfer.MetalCount;
		button.interactable = metalCheck && foodCheck;
	}
}
