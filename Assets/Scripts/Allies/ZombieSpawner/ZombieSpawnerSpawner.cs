using System;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawnerSpawner : ZombieSpawnerComponent
{
	[SerializeField]
	List<ZombieInfo> zombiesToSpawn = new List<ZombieInfo>();
	//[SerializeField]
	//GameObject zombieToSpawn;

	[SerializeField]
	Transform zombieSpawnpoint;
	bool spawnZombie = true;

	internal override void SubscribeToEvents()
	{
		base.SubscribeToEvents();
		eventsProxy.OnZombieSpawn += SpawnZombie;
		var instance = GameInfoSingleton.Instance;
		instance.OnGameWinning += StopSpawn;
	}

	private void StopSpawn()
	{
		spawnZombie = false;
	}

	private void SpawnZombie()
	{
		if (!spawnZombie) return;
		var zombieToSpawn = GetRandomlySpawnedZombie();
		foreach (var zombie in zombieToSpawn)
		{
			Instantiate(zombie, zombieSpawnpoint.position, zombieSpawnpoint.rotation);
		}
	}

	private List<GameObject> GetRandomlySpawnedZombie()
	{
		var result = new List<GameObject>();
		var chance = UnityEngine.Random.Range(0, 100);
		foreach (var e in zombiesToSpawn)
		{
			if (e.SpawnChance>=chance)
			{
				result.Add(e.ZombiePrefab);
			}
		}
		return result;
	}
}
