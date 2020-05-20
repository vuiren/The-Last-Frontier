using UnityEngine;

public class AttackingRotateBulletSpawnPointToEnemy : AttackingComponent
{
	[SerializeField]
	Transform bulletSpawnPoint;

	[SerializeField]
	Vector3 aimingOffset;

	GameObject target;

	internal override void SubscribeToEvents()
	{
		base.SubscribeToEvents();
		eventsProxy.OnClosestTargetUpdate += UpdateTarget;
	}

	private void UpdateTarget(GameObject obj)
	{
		target = obj;
	}

	private void Update()
	{
		if (!target) return;
		bulletSpawnPoint.right = target.transform.position + aimingOffset - bulletSpawnPoint.transform.position;
	}
}
