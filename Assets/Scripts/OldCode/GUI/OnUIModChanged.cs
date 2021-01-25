using UnityEngine;
using UnityEngine.Events;

public class OnUIModChanged : SingletonSubscriber
{
	[SerializeField]
	UnityEvent OnMainUIMode;

	[SerializeField]
	UnityEvent OnBuildUIMode;

	[SerializeField]
	UnityEvent OnSpawnUIMode;

	[SerializeField]
	UnityEvent onBridgeUI;

	[SerializeField]
	UnityEvent OnWinUIMode;

	[SerializeField]
	UnityEvent OnPauseUIMode;

	private void ChangeMode()
	{
		var guiMode = GUIManager.Instance.GUIMode;
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
			case UIModesEnum.BridgeUI:
				onBridgeUI.Invoke();
				break;
		}
	}

	internal override void UnSubscribeFromEvents()
	{
		var instance = GUIManager.Instance;
		if (!instance) return;
		instance.OnGUIUpdate -= ChangeMode;
	}

	internal override void SubscribeToEvents()
	{
		var instance = GUIManager.Instance;
		instance.OnGUIUpdate += ChangeMode;
	}
}
