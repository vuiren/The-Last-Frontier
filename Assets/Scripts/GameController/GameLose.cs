using System;
using UnityEngine;

public class GameLose : MonoBehaviour
{
	bool changingScene;

	private void Awake()
	{
		GlobalDataTransfer.OnAlliesCountChanged += UpdateList;
		GlobalDataTransfer.OnCasarmsCountChanged += UpdateList;
		GlobalDataTransfer.OnSceneChanging += UpdateBool;
	}

	private void UpdateBool()
	{
		changingScene = true;
	}

	private void UpdateList()
	{
		if (changingScene) return;
		if (GlobalDataTransfer.Allies.Count == 0 && GlobalDataTransfer.Casarms.Count <= 0) 
		{
			GlobalDataTransfer.OnGameOver?.Invoke();
		}
	}
}