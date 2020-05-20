using UnityEngine;
using UnityEngine.UI;

public class AllyButtonInteractiveChange : MonoBehaviour
{
	[SerializeField]
	Button button;

	[SerializeField]
	AllySpawnButtonInfo AllySpawnButtonInfo;

	private void Awake()
	{
		GlobalDataTransfer.OnMetalCountChanged += CheckForMetalIfActive;
		GlobalDataTransfer.OnConsumingFoodCountChanged += CheckForMetalIfActive;
		CheckForMetalIfActive(GlobalDataTransfer.MetalCount);
	}

	private void CheckForMetalIfActive(int metalCount)
	{
		var buttonInfo = AllySpawnButtonInfo.allyInfo.AllyCost;
		bool foodCheck = (buttonInfo.FoodCost + GlobalDataTransfer.ConsumingFoodCount <= GlobalDataTransfer.AvailableFoodAmount);
		bool metalCheck = buttonInfo.MetalCost <= GlobalDataTransfer.MetalCount;
		button.interactable = metalCheck && foodCheck;
	}
}
