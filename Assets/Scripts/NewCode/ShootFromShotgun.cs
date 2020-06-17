using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

public class ShootFromShotgun : MonoBehaviour
{
    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    Transform leftSpawnPointsParent;

    [SerializeField]
    Transform rightSpawnPointsParent;

    [ShowInInspector]
    [ReadOnly]
    DirectionsEnum shootingDirection;

    List<Transform> leftSpawnPoints;
    List<Transform> rightpawnPoints;

    private void Awake()
    {
        leftSpawnPoints = GetSpawnPointsFromParent(leftSpawnPointsParent);
        rightpawnPoints = GetSpawnPointsFromParent(rightSpawnPointsParent);
    }

    private List<Transform> GetSpawnPointsFromParent(Transform leftSpawnPointsParent)
    {
        var result = new List<Transform>();
        for (int i = 0; i < leftSpawnPointsParent.childCount; i++)
        {
            result.Add(leftSpawnPointsParent.GetChild(i));
        }
        return result;
    }

    public void UpdateShootingDirection(GameObject obj)
    {
        if (!obj) return;
        var dif = transform.position.x - obj.transform.position.x;
        shootingDirection = dif < 0 ? DirectionsEnum.East : DirectionsEnum.West;
    }

    public void DoShoot()
    {
        var spawnPoints = shootingDirection == DirectionsEnum.East ? rightpawnPoints : leftSpawnPoints;
        foreach (var bulletSpawnpoint in spawnPoints)
            Instantiate(bulletPrefab, bulletSpawnpoint.position, bulletSpawnpoint.rotation);
    }
}
