using System;
using System.Collections;
using UnityEngine;

public class ZombieSpawnerTimer : ZombieSpawnerComponent
{
	[SerializeField]
	float spawnTime = 3f;

	Coroutine coroutine;
	internal override void SubscribeToEvents()
	{
		base.SubscribeToEvents();
		var instance = GameInfoSingleton.Instance;
		instance.OnGameWinning += StopTimer;
	}

	private void StopTimer()
	{
		StopCoroutine(coroutine);
	}

	private void Start()
	{
		coroutine= StartCoroutine(TimerRoutine());
	}

	private IEnumerator TimerRoutine()
	{
		while (true)
		{
			eventsProxy.OnZombieSpawn?.Invoke();
			yield return new WaitForSeconds(spawnTime);
		}
	}
}