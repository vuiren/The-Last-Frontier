using UnityEngine;

public class ZombieBecomePowerlessOnGameWin : MonoBehaviour
{
	[SerializeField]
	Rigidbody2D rb;

	[SerializeField]
	float burySpeed = 0.3f;

	private void Awake()
	{
		GlobalDataTransfer.OnGameWinning += BuryAndDie;
	}

	private void BuryAndDie()
	{
		gameObject.SetActive(false);
	}

	private void OnDestroy()
	{
		GlobalDataTransfer.OnGameWinning -= BuryAndDie;
	}
}
