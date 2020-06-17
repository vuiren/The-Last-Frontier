using UnityEngine;

public class ChangeUIMode : MonoBehaviour
{
	[SerializeField]
	UIModesEnum modeToSet;

	public void DoChangeUIMode()
	{
		var instance = GameInfoSingleton.Instance;
		instance.GUIMode = modeToSet;//OnUIModeChanged?.Invoke(modeToSet);
	}
}
