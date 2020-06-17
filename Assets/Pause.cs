using UnityEngine;

public class Pause : MonoBehaviour
{
	[SerializeField]
	ChangeUIMode PauseChangeUIMode;

	[SerializeField]
	ChangeUIMode MainMenuUIMode;

	private void Awake()
	{
		var instance = GameInfoSingleton.Instance;
		instance.OnPauseChanged += PauseGame;
	}

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			var instance = GameInfoSingleton.Instance;
			instance.IsGameOnPause = !instance.IsGameOnPause;
		}
	}

	private void PauseGame()
	{
		var instance = GameInfoSingleton.Instance;
		Time.timeScale = instance.IsGameOnPause ? 0 : 1;
		if (instance.IsGameOnPause)
		{
			PauseChangeUIMode.DoChangeUIMode();
		}
		else
			MainMenuUIMode.DoChangeUIMode();
	}
}
