using UnityEngine;

public class AimAtTarget : MonoBehaviour, ITargetUpdateReceiver
{
	[SerializeField]
	Transform leftBulletSpawnPoint;
	
	[SerializeField]
	Transform rightBulletSpawnPoint;

	[SerializeField]
	Vector3 aimingOffset;

	GameObject target;

	public void UpdateTarget(GameObject obj)
	{
		target = obj;
	}

	private void Update()
	{
		if (!target) return;
		leftBulletSpawnPoint.right = target.transform.position + aimingOffset - leftBulletSpawnPoint.transform.position;
		rightBulletSpawnPoint.right = target.transform.position + aimingOffset - leftBulletSpawnPoint.transform.position;
	}
}
