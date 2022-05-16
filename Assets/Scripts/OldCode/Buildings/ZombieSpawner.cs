using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
	[SerializeField] List<GameObject> zombiesPrefabs;
	[SerializeField] Transform spawnPointsParent;
	//[SerializeField] bool enableSpawnLimit;

	[SerializeField] 
	int maxAlliesSpawned;

	[SerializeField] List<Transform> spawnPoints = new List<Transform>();
	 [SerializeField] GameObject[] spawnedZombies;

	private void Start()
	{
		spawnedZombies = new GameObject[maxAlliesSpawned];
		FetchSpawnPoint();
	}
	
	private void FetchSpawnPoint()
	{
		for (int i = 0; i < spawnPointsParent.childCount; i++)
		{
			var child = spawnPointsParent.GetChild(i);
			spawnPoints.Add(child);
		}
	}

	public void SpawnAlly()
	{
		var freeIndex = GetNextFreeSlot();
		if (freeIndex == -1) return;
		var spawnPoint = GetSpawnPoint();
		var zombiePrefab = zombiesPrefabs[Random.Range(0, zombiesPrefabs.Count - 1)];
		var ally = Instantiate(zombiePrefab, spawnPoint.position, spawnPoint.rotation);
		spawnedZombies[freeIndex] = ally;
	}

	private int GetNextFreeSlot()
	{
		for (int i = 0; i < spawnedZombies.Length; i++)
		{
			GameObject e = spawnedZombies[i];
			if (!e) return i;
		}
		return -1;
	}

	private Transform GetSpawnPoint()
	{
		var index = Random.Range(0, spawnPoints.Count);
		var spawnPoint = spawnPoints[index];
		return spawnPoint;
	}
}