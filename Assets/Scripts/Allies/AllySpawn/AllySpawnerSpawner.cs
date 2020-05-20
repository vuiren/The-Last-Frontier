using UnityEngine;

public class AllySpawnerSpawner : AllySpawnerComponet
{
	[SerializeField]
	Transform spawnPoint;

	internal override void SubscribeToEvents()
	{
		base.SubscribeToEvents();
		eventsProxy.OnSpawning += Spawn;
	}

	private void Spawn(AllyInfo obj)
	{
		Instantiate(obj.AllyPrefab, spawnPoint.position, spawnPoint.rotation);
		GlobalDataTransfer.MetalCount -= obj.AllyCost.MetalCost;
	//	GlobalDataTransfer.ConsumingFoodCount += obj.AllyCost.FoodCost;
	}
}
