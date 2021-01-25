using UnityEngine;

public class IncreasePlayerResources : MonoBehaviour
{
	[SerializeField]
	GameResources resourcesIncreaseCount;

	public void DoIncreaseResourcesCount()
	{
		var instance = PlayerResources.Instance;
		instance.AddResources(resourcesIncreaseCount.MetalCount, resourcesIncreaseCount.FoodCount);
	}
}