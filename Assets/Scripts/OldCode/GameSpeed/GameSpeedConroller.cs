using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.InputSystem.InputAction;

public enum PauseAction { Pause, Resume}
public class GameSpeedConroller : MonoBehaviour
{
	[SerializeField]
	UIModesEnum pauseUI = UIModesEnum.PauseUI;

	[ReadOnly]
	[SerializeField]
	UIModesEnum resumeUI;

	[SerializeField]

	ChangeUIMode changeUIMode;

	//[SerializeField]
	//UIModesEnum resumeUI = UIModesEnum.MainUI;

	[SerializeField]
	UnityEvent onPause;

	[SerializeField]
	UnityEvent onResume;

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			PauseGame();
		}
	}

	public void PauseGame()
	{
		var action = Mathf.Approximately(Time.timeScale, 0f) ? PauseAction.Resume : PauseAction.Pause;

		if (action == PauseAction.Pause)
		{
			Time.timeScale = 0f;
			var instance = GUIManager.Instance;
			resumeUI = instance.GUIMode;
			onPause.Invoke();
			changeUIMode.DoChangeUIMode(pauseUI);
		}
		else
		{
			Time.timeScale = 1f;
			onResume.Invoke();
			changeUIMode.DoChangeUIMode(resumeUI);
		}
	}

	public void SpeedGame(CallbackContext callbackContext)
	{
		if (!callbackContext.performed) return;
		Time.timeScale += 0.5f;
		Time.timeScale = Mathf.Clamp(Time.timeScale, 0, 2f);
	}

	public void SlowGame(CallbackContext callbackContext)
	{
		if (!callbackContext.performed) return;
		var timeScaleZero = Mathf.Approximately(Time.timeScale, 0f);
		if(timeScaleZero)
		{
			Time.timeScale = 0.5f;
		}
		else
		{
			Time.timeScale -= 0.5f;
		}
		Time.timeScale = Mathf.Clamp(Time.timeScale, 0, 2f);
	}

	[Button]
	public void PlayPauseGame(bool pause)
	{
		Time.timeScale = pause ? 0f : 1f;
	}
}
