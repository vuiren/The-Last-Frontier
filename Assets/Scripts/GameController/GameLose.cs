using System;
using UnityEngine;

public class GameLose : MonoBehaviour
{
	bool changingScene;

	private void Awake()
	{
		var instance = GameInfoSingleton.Instance;

		instance.OnAlliesCountChanged += UpdateList;
		instance.OnCasarmsCountChanged += UpdateList;
		instance.OnSceneChanging += UpdateBool;
	}

	private void UpdateBool()
	{
		changingScene = true;
	}

	private void UpdateList()
	{
		if (changingScene) return;
		var instance = GameInfoSingleton.Instance;

		if (instance.Allies.Count == 0 && instance.Casarms.Count <= 0) 
		{
			instance.OnGameOver?.Invoke();
		}
	}
}