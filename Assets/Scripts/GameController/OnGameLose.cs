using UnityEngine;
using UnityEngine.Events;

public class OnGameLose : MonoBehaviour
{
	[SerializeField]
	UnityEvent onGameLose;

	private void Awake()
	{
		GlobalDataTransfer.OnGameOver += onGameLose.Invoke;
	}
}
