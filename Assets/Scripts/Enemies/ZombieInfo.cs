using UnityEngine;

[CreateAssetMenu(fileName = "New Zombie", menuName = "Zombies")]
public class ZombieInfo : ScriptableObject
{
	public GameObject ZombiePrefab;
	public float SpawnChance;
}
