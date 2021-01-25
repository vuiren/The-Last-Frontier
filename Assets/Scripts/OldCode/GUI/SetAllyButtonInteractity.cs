using UnityEngine;
using UnityEngine.UI;

public class SetAllyButtonInteractity : SingletonSubscriber
{
	[SerializeField]
	Button button;

	[SerializeField]
	SpawnButtonInfo AllySpawnButtonInfo;

	internal override void SubscribeToEvents()
	{
		var instance = GUIManager.Instance;
		instance.OnGUIUpdate += CheckForMetalIfActive;
	}

	internal override void UnSubscribeFromEvents()
	{
		var instance = GUIManager.Instance;
		if (!instance) return;
		instance.OnGUIUpdate -= CheckForMetalIfActive;
	}

	private void Start()
	{
		CheckForMetalIfActive();
	}

	private void CheckForMetalIfActive()
	{
		var buttonInfo = AllySpawnButtonInfo.allyInfo.CreationCost;
		var instance = PlayerResources.Instance;
	//	bool foodCheck = (buttonInfo.FoodCount + instance.ConsumingFoodCount <= instance.AvailableFoodAmount);
	//	bool metalCheck = buttonInfo.MetalCount <= instance.MetalCount;
	//	button.interactable = metalCheck && foodCheck;
	}
}
