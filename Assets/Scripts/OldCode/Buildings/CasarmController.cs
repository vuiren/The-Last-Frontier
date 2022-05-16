using UnityEngine;

public class CasarmController : MonoBehaviour
{
	[SerializeField]
	GameObject spawnPoint;

	AllySpawnerController allySpawner;

	private void Start()
	{
		FindAllySpawner();
	}

	private void FindAllySpawner()
	{
		var bootstrap = GameObject.FindGameObjectWithTag("Bootstrap");
		if (bootstrap == null) return;
		//allySpawner = bootstrap.GetComponent<ControllersKeeper>().AllySpawnerController;
	}

	public void SpawnAlly(CreatingInfo ally)
	{
		var allyPrefab = ally.CreationPrefab;
		Instantiate(allyPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
	}

	public void SetGameManagerCasarm()
	{
		if (!allySpawner)
			FindAllySpawner();
		allySpawner.SetCasarmController(this);
	}
}
