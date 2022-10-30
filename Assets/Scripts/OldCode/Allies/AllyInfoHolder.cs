using UnityEngine;

public class AllyInfoHolder : MonoBehaviour
{
	public CreatingInfo allyInfo;

	private void Awake()
	{
		/*var instance = GameManager.Instance;
		instance.ConsumingFoodCount += allyInfo.CreationCost.FoodCount;*/
	}

	private void OnDestroy()
	{
		/*var instance = GameManager.Instance;
		instance.ConsumingFoodCount -= allyInfo.CreationCost.FoodCount;*/
	}
}
