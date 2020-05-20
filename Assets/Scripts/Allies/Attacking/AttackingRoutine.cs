using UnityEngine;

public class AttackingRoutine : AttackingComponent
{
	[SerializeField]
	float timeBetweenAttacks = 1f;

	[SerializeField]
	float attackStartDistance = 0.2f;

	GameObject target;
	float curTime;

	internal override void SubscribeToEvents()
	{
		base.SubscribeToEvents();
		eventsProxy.TimeBetweenAttacks = timeBetweenAttacks;
		eventsProxy.OnClosestTargetUpdate += UpdateTarget;
	}

	internal override void EnableComponent()
	{
		base.EnableComponent();
		curTime = 0;
		eventsProxy.CurReloadingTime = curTime;
	}

	protected void Update()
	{
		if (!target) return;
		var bounds = target.GetComponent<Collider2D>().bounds;
		var leftestPoint = bounds.center - bounds.extents;
		var rightestPoint = bounds.center + bounds.extents;
		var midPoint = target.transform.position;
		var leftReached = DistanceTracker.IsObjectReachedDestination(transform.position, leftestPoint, attackStartDistance);
		var rightReached = DistanceTracker.IsObjectReachedDestination(transform.position, rightestPoint, attackStartDistance);
		var centerReached = DistanceTracker.IsObjectReachedDestination(transform.position, midPoint, attackStartDistance);
		if (!ReadyToAttack()) return;
		if (leftReached || rightReached || centerReached)
		{
			Attack();
		}
	}

	private void Attack()
	{
		curTime = timeBetweenAttacks;
		eventsProxy.OnEnemyHit?.Invoke();
	}

	private bool ReadyToAttack()
	{
		ReloadProcess();
		return curTime <= 0;
	}

	void ReloadProcess()
	{
		curTime -= Time.deltaTime;
		eventsProxy.CurReloadingTime = curTime;
	}

	private void UpdateTarget(GameObject obj) => target = obj;
}