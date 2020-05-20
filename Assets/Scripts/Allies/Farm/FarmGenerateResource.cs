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
		GlobalDataTransfer.MetalCount += resourceToGenerate.MetalCost;
		GlobalDataTransfer.ConsumingFoodCount += resourceToGenerate.FoodCost;
	}
}
