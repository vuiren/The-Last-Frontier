using UnityEngine;
using UnityEngine.Events;

public class OnGameWin : MonoBehaviour
{
	[SerializeField]
	UnityEvent onGameWinEvents;

	private void Awake()
	{
		var instance = GameInfoSingleton.Instance;

		instance.OnGameWinning += onGameWinEvents.Invoke;
	}
}
