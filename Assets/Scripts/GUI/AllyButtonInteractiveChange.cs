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
		var instance = GameInfoSingleton.Instance;
		instance.OnMetalCountChanged += CheckForMetalIfActive;
		instance.OnConsumingFoodCountChanged += CheckForMetalIfActive;
		CheckForMetalIfActive(instance.MetalCount);
	}

	private void CheckForMetalIfActive(int metalCount)
	{
		var buttonInfo = AllySpawnButtonInfo.allyInfo.AllyCost;
		var instance = GameInfoSingleton.Instance;
		bool foodCheck = (buttonInfo.FoodCost + instance.ConsumingFoodCount <= instance.AvailableFoodAmount);
		bool metalCheck = buttonInfo.MetalCost <= instance.MetalCount;
		button.interactable = metalCheck && foodCheck;
	}
}
