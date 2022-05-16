using QFSW.QC;
using UnityEngine;
using UnityEngine.Events;

public enum PauseAction { Pause, Resume}
public class GameSpeedController : MonoBehaviour
{
	[SerializeField] private UIModesEnum pauseUI = UIModesEnum.PauseUI;
	
	[SerializeField]
	private UIModesEnum resumeUI;

	[SerializeField] private ChangeUIMode changeUIMode;
	
	[SerializeField] private UnityEvent onPause, onResume;
	
	[Command("game.pause")]
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

	[Command("game.speedUp")]
	private void SpeedGame()
	{
		Time.timeScale += 0.5f;
		Time.timeScale = Mathf.Clamp(Time.timeScale, 0, 2f);
	}

	[Command("game.speedDown")]
	private void SlowGame()
	{
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

	public void PlayPauseGame(bool pause)
	{
		Time.timeScale = pause ? 0f : 1f;
	}
}
