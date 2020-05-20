using UnityEngine;
using UnityEngine.Events;

public class OnGameWin : MonoBehaviour
{
	[SerializeField]
	UnityEvent onGameWinEvents;

	private void Awake()
	{
		GlobalDataTransfer.OnGameWinning += onGameWinEvents.Invoke;
	}
}
