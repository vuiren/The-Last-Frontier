using UnityEngine;

public class ChangeUIMode : MonoBehaviour
{
	[SerializeField]
	UIModesEnum modeToSet = UIModesEnum.MainUI;

	public void DoChangeUIMode()
	{
		var instance = GUIManager.Instance;
		instance.GUIMode = modeToSet;//OnUIModeChanged?.Invoke(modeToSet);
		instance.OnGUIUpdate?.Invoke();
	}

	public void DoChangeUIMode(UIModesEnum uiModeToSet)
	{
		modeToSet = uiModeToSet;
		DoChangeUIMode();
	}
}
