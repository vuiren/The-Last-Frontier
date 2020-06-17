using UnityEngine;
using UnityEngine.Events;

public class AttackController : MonoBehaviour, ITargetUpdateReceiver
{
	[SerializeField]
	float timeBetweenAttacks = 1f;

	[SerializeField]
	float attackStartDistance = 0.2f;

	[SerializeField]
	UnityEvent onAttack;

	GameObject target;
	float remainingTimeBeforeAttack;

	protected void Update()
	{
		ReloadProcess();
		if (!target) return;
		TargetInAttackingRange();
		if (ReadyToAttack())
			Attack();
	}

	private bool TargetInAttackingRange()
	{
		var bounds = target.GetComponent<Collider2D>().bounds;
		var leftestPoint = bounds.center - bounds.extents;
		var rightestPoint = bounds.center + bounds.extents;
		var midPoint = target.transform.position;
		var leftReached = DistanceTracker.IsObjectReachedDestination(transform.position, leftestPoint, attackStartDistance);
		var rightReached = DistanceTracker.IsObjectReachedDestination(transform.position, rightestPoint, attackStartDistance);
		var centerReached = DistanceTracker.IsObjectReachedDestination(transform.position, midPoint, attackStartDistance);
		return leftReached || rightReached || centerReached;
	}

	private void Attack()
	{
		remainingTimeBeforeAttack = timeBetweenAttacks;
		onAttack.Invoke();
	}

	private bool ReadyToAttack()
	{
		var timeCheck= remainingTimeBeforeAttack <= 0;
		var disanceCheck = TargetInAttackingRange();
		return timeCheck && disanceCheck;
	}

	void ReloadProcess()
	{
		remainingTimeBeforeAttack -= Time.deltaTime;
	}

	public void UpdateTarget(GameObject obj) => target = obj;
}
