using System;

public class PlayerResources : Singleton<PlayerResources>
{
	public GameResources AvailableResources { get; set; } = new GameResources(50, 50);
	public Action<GameResources> OnGameResourcesChanged { get; set; }

	public void CreatingResourcesChange(CreatingInfo creatingInfo)
	{
		AvailableResources.MetalCount -= creatingInfo.CreationCost.MetalCount;
		AvailableResources.FoodCount -= creatingInfo.CreationCost.FoodCount;
		OnGameResourcesChanged?.Invoke(AvailableResources);
	}

	public void AddResources(int metalCount, int foodCount)
	{
		AvailableResources.MetalCount += metalCount;
		AvailableResources.FoodCount += foodCount;
		OnGameResourcesChanged?.Invoke(AvailableResources);
	}

	public void AddResources(GameResources gameResources)
	{
		AddResources(gameResources.MetalCount, gameResources.FoodCount);
	}

	public void DestroyingResourcesChange(CreatingInfo creatingInfo)
	{
		AvailableResources.FoodCount += creatingInfo.CreationCost.FoodCount;
		OnGameResourcesChanged?.Invoke(AvailableResources);
	}
}
