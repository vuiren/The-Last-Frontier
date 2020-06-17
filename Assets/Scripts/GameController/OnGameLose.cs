using UnityEngine;
using UnityEngine.Events;

public class OnGameLose : MonoBehaviour
{
	[SerializeField]
	UnityEvent onGameLose;

	private void Awake()
	{
		var instance = GameInfoSingleton.Instance;

		instance.OnGameOver += onGameLose.Invoke;
	}
}
