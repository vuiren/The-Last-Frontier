using System.Collections.Generic;
using UnityEngine;

public class SpawnShotProjectiles
{
    List<Transform> leftSpawnpoints = new List<Transform>();
    List<Transform> rightSpawnpoints = new List<Transform>();
    DirectionsEnum shootingDirection;

    GameObject parent;

    public SpawnShotProjectiles(GameObject parent, Transform leftSpawnpointsParent, Transform rightSpawnpointsParent)
    {
        this.parent = parent;
        SetSpawnPoints(leftSpawnpointsParent, rightSpawnpointsParent);
    }

    public void SetSpawnPoints(Transform leftSpawnpointsParent, Transform rightSpawnpointsParent)
    {
        leftSpawnpoints = GetSpawnPointsFromParent(leftSpawnpointsParent);
        rightSpawnpoints = GetSpawnPointsFromParent(rightSpawnpointsParent);
    }

    private List<Transform> GetSpawnPointsFromParent(Transform spawnPointsParent)
    {
        var result = new List<Transform>();
        for (int i = 0; i < spawnPointsParent.childCount; i++)
        {
            var child = spawnPointsParent.GetChild(i);
            if (!child.gameObject.activeSelf) continue;
            result.Add(child);
        }
        return result;
    }

    private void ChooseShootingDirection(GameObject obj)
    {
        var dif = parent.transform.position.x - obj.transform.position.x;
        shootingDirection = dif < 0 ? DirectionsEnum.Right : DirectionsEnum.Left;
    }

    public void Shoot(GameObject projectilePrefab, GameObject target, int damageCount)
    {
        ChooseShootingDirection(target);
        var bulletSpawnpoints = shootingDirection == DirectionsEnum.Right ? rightSpawnpoints : leftSpawnpoints;

        foreach(var e in bulletSpawnpoints)
        {
            var bullet = GameObject.Instantiate(projectilePrefab, e.position, e.rotation);
            bullet.GetComponent<IProjectile>().SetDamageCount(damageCount);
        }
    }

    public List<Transform> GetSpawnPoints(GameObject target)
    {
        ChooseShootingDirection(target);
        var bulletSpawnpoints = shootingDirection == DirectionsEnum.Right ? rightSpawnpoints : leftSpawnpoints;
        return bulletSpawnpoints;
    }

    private void OnDrawGizmosSelected()
    {
        foreach (var e in leftSpawnpoints)
            Gizmos.DrawWireSphere(e.position, 0.01f);
        foreach (var e in rightSpawnpoints)
            Gizmos.DrawWireSphere(e.position, 0.01f);
    }
}
