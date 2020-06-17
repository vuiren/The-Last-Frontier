using UnityEngine;
using UnityEngine.Events;

public class UIModChanger : MonoBehaviour
{
	[SerializeField]
	UnityEvent OnMainUIMode;

	[SerializeField]
	UnityEvent OnBuildUIMode;

	[SerializeField]
	UnityEvent OnSpawnUIMode;

	[SerializeField]
	UnityEvent OnWinUIMode;

	[SerializeField]
	UnityEvent OnPauseUIMode;

	private void Awake()
	{
		var instance = GameInfoSingleton.Instance;
		instance.OnGUIModeChanged += ChangeMode;
	}

	private void OnDestroy()
	{
		var instance = GameInfoSingleton.Instance;
		if (!instance) return;
		instance.OnGUIModeChanged -= ChangeMode;
	}

	private void ChangeMode()
	{
		var guiMode = GameInfoSingleton.Instance.GUIMode;
		switch(guiMode)
		{
			case UIModesEnum.BuildUI:
				OnBuildUIMode.Invoke();
				break;
			case UIModesEnum.MainUI:
				OnMainUIMode.Invoke();
				break;
			case UIModesEnum.SpawnUI:
				OnSpawnUIMode.Invoke();
				break;
			case UIModesEnum.WinningUI:
				OnWinUIMode.Invoke();
				break;
			case UIModesEnum.PauseUI:
				OnPauseUIMode.Invoke();
				break;
		}
	}
}
