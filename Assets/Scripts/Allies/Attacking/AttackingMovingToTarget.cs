using Sirenix.OdinInspector;
using UnityEngine;

public class AttackingMovingToTarget : AttackingComponent
{
	[SerializeField]
	protected Rigidbody2D rb;

	[SerializeField]
	protected float moveSpeed = 0.2f;

	[SerializeField]
	protected float stopDistance = 0.2f;

	[ShowInInspector]
	[ReadOnly]
	protected DirectionsEnum movingDirection;

	protected Bounds targetBounds;
	protected GameObject target;

	internal override void SubscribeToEvents()
	{
		base.SubscribeToEvents();
		eventsProxy.OnClosestTargetUpdate += StartMovingToPosition;
	}

	protected void Update()
	{
		if(!target.gameObject)
		{
			StopMoving();
			return;
		}
		var bounds = target.GetComponent<Collider2D>().bounds;
		var leftestPoint = bounds.center - bounds.extents;
		var rightestPoint = bounds.center + bounds.extents;
		var midPoint = target.transform.position;
		var leftReached = DistanceTracker.IsObjectReachedDestination(transform.position, leftestPoint, stopDistance);
		var rightReached = DistanceTracker.IsObjectReachedDestination(transform.position, rightestPoint, stopDistance);
		var centerReached = DistanceTracker.IsObjectReachedDestination(transform.position, midPoint, stopDistance);
		if (leftReached || rightReached || centerReached)
		{
			StopMoving();
		}
		else
		{
			StartMovingToPosition(target);
		}
	}

	protected void StartMovingToPosition(GameObject target)
	{
		if(!target)
		{
			StopMoving();
			return;
		}
		this.target = target;
		targetBounds = target.GetComponent<BoxCollider2D>().bounds;
		ChooseMovingDirection(target.transform.position);
		rb.velocity = new Vector2(movingDirection == DirectionsEnum.East ? moveSpeed : -moveSpeed, 0);
	}

	protected void StopMoving()
	{
		rb.velocity = new Vector2();
	}

	protected void ChooseMovingDirection(Vector3 targetPos)
	{
		var dif = transform.position.x - targetPos.x;
		movingDirection = dif < 0 ? DirectionsEnum.East : DirectionsEnum.West;
	}

	internal override void EnableComponent()
	{
		if (!target)
			StartMovingToPosition(target);
	}

	internal override void DisableComponent()
	{
		StopMoving();
	}
}