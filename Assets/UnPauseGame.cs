using UnityEngine;

public class UnPauseGame : MonoBehaviour
{
	public void ResumeGame()
	{
		var instance = GameInfoSingleton.Instance;

		instance.IsGameOnPause = !instance.IsGameOnPause;
	}
}
