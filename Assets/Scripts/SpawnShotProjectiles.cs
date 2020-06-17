using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

public class SpawnShotProjectiles : MonoBehaviour, ITargetUpdateReceiver
{
    [SerializeField]
    GameObject projectilePrefab;

    [SerializeField]
    Transform leftSpawnpointsParent;

    [SerializeField]
    Transform rightSpawnpointsParent;

    [ShowInInspector]
    [ReadOnly]
    GameObject target;

    List<Transform> leftSpawnpoints = new List<Transform>();
    List<Transform> rightSpawnpoints = new List<Transform>();
    DirectionsEnum shootingDirection;

    private void Awake()
    {
        SetSpawnPoints();
    }

    private void SetSpawnPoints()
    {
        leftSpawnpoints = GetSpawnPointsFromParent(leftSpawnpointsParent);
        rightSpawnpoints = GetSpawnPointsFromParent(rightSpawnpointsParent);
    }

    private List<Transform> GetSpawnPointsFromParent(Transform spawnPointsParent)
    {
        var result = new List<Transform>();
        for (int i = 0; i < spawnPointsParent.childCount; i++)
        {
            result.Add(spawnPointsParent.GetChild(i));
        }
        return result;
    }

    public void UpdateTarget(GameObject obj)
    {
        target = obj;
        if (!target) return;

        RecalculateShootingDirection(obj);
    }

    private void RecalculateShootingDirection(GameObject obj)
    {
        var dif = transform.position.x - obj.transform.position.x;
        shootingDirection = dif < 0 ? DirectionsEnum.East : DirectionsEnum.West;
    }

    public void DoSpawnProjectilesAccordingToShootingDirection()
    {
        var bulletSpawnpoints = shootingDirection == DirectionsEnum.East ? rightSpawnpoints : leftSpawnpoints;

        foreach(var e in bulletSpawnpoints)
        {
            Instantiate(projectilePrefab, e.position, e.rotation);
        }
    }
}
