using UnityEngine;

public class GamePauser : MonoBehaviour
{
	public void PauseGame()
	{
		Time.timeScale = 0;
	}

	public void UnPauseGame()
	{
		Time.timeScale = 1;
	}
}
