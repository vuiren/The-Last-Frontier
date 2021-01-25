using UnityEngine;
using UnityEngine.UI;

public class SyncFoodCountUI : MonoBehaviour
{
	[SerializeField]
	Text text;

	string startText;

	public void UpdateFoodCount(GameResources gameResources)
	{
		var a = gameResources.FoodCount;
		if (text != null)
			text.text = startText + " " + a;
	}
}
