using System;
using UnityEngine;

[Serializable]
public class GameResources
{
	[SerializeField]
	private int metalCount;

	[SerializeField]
	private int foodCount;

	public GameResources(int metalCount, int foodCount)
	{
		MetalCount = metalCount;
		FoodCount = foodCount;
	}

	public int MetalCount { get => metalCount; set => metalCount = value; }
	public int FoodCount { get => foodCount; set => foodCount = value; }
}
