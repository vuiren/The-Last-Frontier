using UnityEngine;

public class ChangeUIMode : MonoBehaviour
{
	[SerializeField]
	UIModesEnum modeToSet;

	public void DoChangeUIMode()
	{
		GlobalDataTransfer.OnUIModeChange?.Invoke(modeToSet);
	}
}
