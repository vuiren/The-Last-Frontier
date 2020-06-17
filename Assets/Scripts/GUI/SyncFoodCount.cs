using UnityEngine;
using UnityEngine.UI;

public class SyncFoodCount : MonoBehaviour
{
	[SerializeField]
	Text text;

	string startText;

	private void Awake()
	{
		//	startText = text.text;
		var instance = GameInfoSingleton.Instance;

		instance.OnConsumingFoodCountChanged += UpdateFoodCount;
		instance.OnAvailableFoodAmountChanged += UpdateFoodCount;
		UpdateFoodCount(0);
	}

	private void UpdateFoodCount(int obj)
	{
		var instance = GameInfoSingleton.Instance;
		var a = instance.ConsumingFoodCount + " / " + instance.AvailableFoodAmount;
		if (text != null)
			text.text = startText + " " + a;
	}
}
