using UnityEngine;

public class Pause : SingletonSubscriber
{
	[SerializeField]
	ChangeUIMode changeUIMode;

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			/*var instance = GameManager.Instance;
			instance.IsGameOnPause = !instance.IsGameOnPause;*/
		}
	}

	private void PauseGame()
	{
		/*var instance = GameManager.Instance;
		var pause = instance.IsGameOnPause;
		Time.timeScale = instance.IsGameOnPause ? 0 : 1;
		if (instance.IsGameOnPause)
		{
			changeUIMode.DoChangeUIMode(pause ? UIModesEnum.PauseUI : UIModesEnum.MainUI);
		}*/
	}

	internal override void UnSubscribeFromEvents()
	{
		/*var instance = GameManager.Instance;
		if (!instance) return;
		instance.OnPauseChanged -= PauseGame;*/
	}

	internal override void SubscribeToEvents()
	{
		/*var instance = GameManager.Instance;
		instance.OnPauseChanged += PauseGame;*/
	}
}
