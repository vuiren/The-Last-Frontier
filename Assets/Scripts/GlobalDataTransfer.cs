using System;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalDataTransfer
{
	private static int consumingFoodCount = 0;
	private static int availableFoodAmount = 10;

	internal static void AddAlly(GameObject gameObject)
	{
		Allies.Add(gameObject);
		OnAlliesCountChanged?.Invoke();
	}

	internal static void RemoveAlly(GameObject gameObject)
	{
		Allies.Remove(gameObject);
		OnAlliesCountChanged?.Invoke();
	}

	internal static void ResetVariables()
	{
		metalCount = 10;
		gameOnPause = false;
		Time.timeScale = 1;
		ActiveCasarm = null;
		OnAllyDeath = null;
		OnUIModeChange = null;
		OnCommandTypeChange = null;
		OnBuildingInfoChange = null;
		OnGameWinning = null;
		OnConsumingFoodCountChanged = null;
		OnAvailableFoodAmountChanged = null;
		OnMetalCountChanged = null;
		OnSquadListChanger = null;
	}

	private static int metalCount = 10;

	public static Action OnSceneChanging { get; set; }
	public static AllySpawnGlobabEventsSubscriber ActiveCasarm;
	private static bool gameOnPause = false;
	private static List<GameObject> allies = new List<GameObject>();
	private static List<GameObject> casarms = new List<GameObject>();

	public static List<GameObject> Allies
	{
		get => allies; set
		{
			allies = value;
			OnAlliesCountChanged?.Invoke();
		}
	}
	public static List<GameObject> Casarms
	{
		get => casarms; set
		{
			casarms = value;
			OnCasarmsCountChanged?.Invoke();
		}
	}

	public static Action OnCasarmsCountChanged { get; set; }
	public static Action OnAlliesCountChanged { get; set; }
	public static Action<Transform> OnAllyDeath { get; set; }
	public static Action<UIModesEnum> OnUIModeChange { get; set; }
	public static Action<CommandsEnum> OnCommandTypeChange { get; set; }
	public static Action<Building.BuildingInfo> OnBuildingInfoChange { get; set; }
	public static Action OnPauseChanged { get; set; }
	public static Action OnGameWinning { get; set; }
	public static Action OnGameOver { get; set; }

	public static Action<int> OnConsumingFoodCountChanged { get; set; }
	public static Action<int> OnAvailableFoodAmountChanged { get; set; }
	public static Action<int> OnMetalCountChanged { get; set; }

	public static int MetalCount
	{
		get => metalCount; set
		{
			metalCount = value;
			OnMetalCountChanged?.Invoke(value);
		}
	}

	public static int AvailableFoodAmount
	{
		get => availableFoodAmount; set
		{
			availableFoodAmount = value;
			OnAvailableFoodAmountChanged?.Invoke(value);
		}
	}

	public static int ConsumingFoodCount
	{
		get => consumingFoodCount; set
		{
			consumingFoodCount = value;
			OnConsumingFoodCountChanged?.Invoke(value);
		}
	}

	public static Action<List<Transform>> OnSquadListChanger { get; internal set; }
	public static bool GameOnPause
	{
		get => gameOnPause; set
		{
			gameOnPause = value;
			OnPauseChanged?.Invoke();
		}
	}
}
