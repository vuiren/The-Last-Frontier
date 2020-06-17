using UnityEngine;

public class ZombieBecomePowerlessOnGameWin : MonoBehaviour
{
	[SerializeField]
	Rigidbody2D rb;

	[SerializeField]
	float burySpeed = 0.3f;

	private void Awake()
	{
		var instance = GameInfoSingleton.Instance;
		instance.OnGameWinning += BuryAndDie;
	}

	private void BuryAndDie()
	{
		gameObject.SetActive(false);
	}

	private void OnDestroy()
	{
		var instance = GameInfoSingleton.Instance;
		if (instance)
			instance.OnGameWinning -= BuryAndDie;
	}
}