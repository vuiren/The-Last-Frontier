using UnityEngine;

public class UnPauseGame : MonoBehaviour
{
	public void ResumeGame()
	{
		GlobalDataTransfer.GameOnPause = !GlobalDataTransfer.GameOnPause;
	}
}
