using UnityEngine;
using UnityEngine.UI;

public class SyncAllySpawnUI : MonoBehaviour
{
	[SerializeField] Image allyImage;
	[SerializeField] Text foodCostText;
	[SerializeField] Text metalCostText;

	public void DoSyncUI(CreatingInfo creatingInfo)
	{
		allyImage.sprite = creatingInfo.CreationImage;
		var cost = creatingInfo.CreationCost;
		foodCostText.text = cost.FoodCount.ToString();
		metalCostText.text = cost.MetalCount.ToString();
	}
}
