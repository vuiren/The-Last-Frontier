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
		GlobalDataTransfer.OnConsumingFoodCountChanged += UpdateFoodCount;
		GlobalDataTransfer.OnAvailableFoodAmountChanged += UpdateFoodCount;
		UpdateFoodCount(0);
	}

	private void UpdateFoodCount(int obj)
	{
		var a = GlobalDataTransfer.ConsumingFoodCount + " / " + GlobalDataTransfer.AvailableFoodAmount;
		if (text != null)
			text.text = startText + " " + a;
	}
}
