public class GameLose : SingletonSubscriber
{
	bool changingScene;

	internal override void SubscribeToEvents()
	{
		/*var instance = GameManager.Instance;

//		instance.OnCasarmsCountChanged += UpdateList;
		instance.OnSceneChanging += UpdateBool;*/
	}

	internal override void UnSubscribeFromEvents()
	{
		/*var instance = GameManager.Instance;
		if (!instance) return;
	//	instance.OnAlliesCountChanged -= UpdateList;
	//	instance.OnCasarmsCountChanged -= UpdateList;
		instance.OnSceneChanging -= UpdateBool;*/
	}

	private void UpdateBool()
	{
		changingScene = true;
	}

	private void UpdateList()
	{
		/*if (changingScene) return;
		var instance = GameManager.Instance;

	/*	if (instance.Allies.Count == 0 && instance.Casarms.Count <= 0) 
		{
			instance.OnGameOver?.Invoke();
		}#1#*/
	}
}