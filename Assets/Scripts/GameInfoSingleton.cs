using System;
using System.Collections.Generic;
using UnityEngine;

public class GameInfoSingleton : Singleton<GameInfoSingleton>
{
	public int consumingFoodCount = 0;
	public int availableFoodAmount = 10;

	#region Events
	public Action OnSceneChanging { get; set; }
	public Action OnAllySpawning { get; set; }

	public Action OnCasarmsCountChanged { get; set; }
	public Action OnAlliesCountChanged { get; set; }
	public Action<Transform> OnAllyDeath { get; set; }
	public Action OnGUIModeChanged { get; set; }
	public Action<CommandsEnum> OnCommandTypeChange { get; set; }
	public Action<Building.BuildingInfo> OnBuildingInfoChange { get; set; }
	public Action OnPauseChanged { get; set; }
	public Action OnGameWinning { get; set; }
	public Action OnGameOver { get; set; }

	public Action<int> OnConsumingFoodCountChanged { get; set; }
	public Action<int> OnAvailableFoodAmountChanged { get; set; }
	public Action<int> OnMetalCountChanged { get; set; }
	public Action<List<Transform>> OnSquadListChanger { get; internal set; }
	#endregion

	public UIModesEnum GUIMode
	{
		get => guiMode; set
		{
			guiMode = value;
			OnGUIModeChanged?.Invoke();
		}
	}

	public void AddAlly(GameObject gameObject)
	{
		Allies.Add(gameObject);
		OnAlliesCountChanged?.Invoke();
	}

	public void RemoveAlly(GameObject gameObject)
	{
		Allies.Remove(gameObject);
		OnAlliesCountChanged?.Invoke();
	}

	public void ResetVariables()
	{
		metalCount = 10;
		isGameOnPause = false;
		Time.timeScale = 1;
		ActiveCasarm = null;
		OnAllyDeath = null;
		OnGUIModeChanged = null;
		OnCommandTypeChange = null;
		OnBuildingInfoChange = null;
		OnGameWinning = null;
		OnConsumingFoodCountChanged = null;
		OnAvailableFoodAmountChanged = null;
		OnMetalCountChanged = null;
		OnSquadListChanger = null;
	}

	private int metalCount = 10;

	public AllySpawnGlobabEventsSubscriber ActiveCasarm;
	private bool isGameOnPause = false;
	private List<GameObject> allies = new List<GameObject>();
	private List<GameObject> casarms = new List<GameObject>();
	private UIModesEnum guiMode;

	public List<GameObject> Allies
	{
		get => allies; set
		{
			allies = value;
			OnAlliesCountChanged?.Invoke();
		}
	}
	public List<GameObject> Casarms
	{
		get => casarms; set
		{
			casarms = value;
			OnCasarmsCountChanged?.Invoke();
		}
	}

	public int MetalCount
	{
		get => metalCount; set
		{
			metalCount = value;
			OnMetalCountChanged?.Invoke(value);
		}
	}

	public int AvailableFoodAmount
	{
		get => availableFoodAmount; set
		{
			availableFoodAmount = value;
			OnAvailableFoodAmountChanged?.Invoke(value);
		}
	}

	public int ConsumingFoodCount
	{
		get => consumingFoodCount; set
		{
			consumingFoodCount = value;
			OnConsumingFoodCountChanged?.Invoke(value);
		}
	}

	public bool IsGameOnPause
	{
		get => isGameOnPause;
		set
		{
			isGameOnPause = value;
			OnPauseChanged?.Invoke();
		}
	}
}
