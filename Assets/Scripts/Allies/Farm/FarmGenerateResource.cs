using UnityEngine;

public class FarmGenerateResource : FarmComponent
{
	[SerializeField]
	Cost resourceToGenerate;

	internal override void SubscribeToEvents()
	{
		base.SubscribeToEvents();
		eventsProxy.OnResourceTimer += Generate;
	}

	private void Generate()
	{
		var instance = GameInfoSingleton.Instance;
		instance.MetalCount += resourceToGenerate.MetalCost;
		instance.ConsumingFoodCount += resourceToGenerate.FoodCost;
	}
}
