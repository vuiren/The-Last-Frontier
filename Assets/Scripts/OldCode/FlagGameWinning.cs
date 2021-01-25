using UnityEngine;
using UnityEngine.Events;

public class FlagGameWinning : MonoBehaviour
{
	[SerializeField]
	UnityEvent onWinningTrigger;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.CompareTag("Ally"))
		{
			WinGame();
		}
	}

	private void WinGame()
	{
		var instance = GameManager.Instance;

		instance.OnGameWinning?.Invoke();
		onWinningTrigger.Invoke();
	}
}
