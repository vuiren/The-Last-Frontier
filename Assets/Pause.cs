using UnityEngine;

public class Pause : MonoBehaviour
{
	[SerializeField]
	ChangeUIMode PauseChangeUIMode;

	[SerializeField]
	ChangeUIMode MainMenuUIMode;

	private void Awake()
	{
		GlobalDataTransfer.OnPauseChanged += PauseGame;
	}

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			GlobalDataTransfer.GameOnPause = !GlobalDataTransfer.GameOnPause;
		}
	}

	private void PauseGame()
	{
		Time.timeScale = GlobalDataTransfer.GameOnPause ? 0 : 1;
		if (GlobalDataTransfer.GameOnPause)
		{
			PauseChangeUIMode.DoChangeUIMode();
		}
		else
			MainMenuUIMode.DoChangeUIMode();
	}
}
