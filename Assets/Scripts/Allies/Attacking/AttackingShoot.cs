using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace Attacking
{
    public class AttackingShoot : AttackingComponent
    {
        [SerializeField]
        GameObject bulletPrefab;

        [SerializeField]
        Transform bulletLeftSpawnpoint;

        [SerializeField]
        Transform bulletRightSpawnpoint;

        [ShowInInspector]
        [ReadOnly]
        DirectionsEnum shootingDirection;

        internal override void SubscribeToEvents()
        {
            base.SubscribeToEvents();
            eventsProxy.OnClosestTargetUpdate += ChooseShootingDirection;
            eventsProxy.OnEnemyHit += SpawnBullet;
        }

        private void ChooseShootingDirection(GameObject obj)
        {
            var dif = transform.position.x - obj.transform.position.x;
            shootingDirection = dif < 0 ? DirectionsEnum.East : DirectionsEnum.West;
        }

        private void SpawnBullet()
        {
            var bulletSpawnpoint = shootingDirection == DirectionsEnum.East ? bulletRightSpawnpoint : bulletLeftSpawnpoint;
            Instantiate(bulletPrefab, bulletSpawnpoint.position, bulletSpawnpoint.rotation);
        }
    }
}
