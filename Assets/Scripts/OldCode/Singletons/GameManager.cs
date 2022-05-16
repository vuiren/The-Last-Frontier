using System;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

	#region Events
	public Action OnSceneChanging { get; set; }
	public Action OnPauseChanged { get; set; }
	public Action OnGameWinning { get; set; }

	public Action<BuildingCreatingInfo> onBuildingCreation { get; set; } 
	#endregion

	public void ResetVariables()
	{
		//MetalCount = 10;
		isGameOnPause = false;
		Time.timeScale = 1;
	}

	private bool isGameOnPause = false;
	
	public int ConsumingFoodCount { get; set; } = 0;

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
