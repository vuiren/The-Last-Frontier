using UnityEngine;

namespace Assets.Scripts.Attack
{
    public class RangedAttackController : AttackController
	{
		[SerializeField]
		Transform leftSpawnpointsParent;

		[SerializeField]
		Transform rightSpawnpointsParent;

		SpawnShotProjectiles spawnShotProjectiles;
		AimObjectsAtTarget aimObjectsAtTarget;

		protected override void AddComponents()
		{
			base.AddComponents();
			spawnShotProjectiles = new SpawnShotProjectiles(NPCInfoHolder.gameObject, leftSpawnpointsParent, rightSpawnpointsParent);
			aimObjectsAtTarget = new AimObjectsAtTarget();
		}

		protected override void SubscribeToEvents()
		{
			base.SubscribeToEvents();
			onAttack += (() =>
			{
				AttackSettings attackSettings = NPCInfoHolder.NPCInfo.AttackSettings;
				GameObject projectilePrefab = attackSettings.ProjectilePrefab;

				spawnShotProjectiles.Shoot(projectilePrefab, NPCInfoHolder.AttackTarget, attackSettings.DamageCount);
			});

			onAttack += (() =>
			  {
				  var spawnPoints = spawnShotProjectiles.GetSpawnPoints(NPCInfoHolder.AttackTarget);
				  aimObjectsAtTarget.Aim(NPCInfoHolder.AttackTarget, spawnPoints);
			  });
		}
	}
}