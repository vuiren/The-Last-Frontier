using System;
using UnityEngine;

public class ZombieSpawnerEventsProxy : MonoBehaviour
{
	public Action OnZombieSpawn { get; set; }
	public Action OnZombieSpawned { get; set; }
}
