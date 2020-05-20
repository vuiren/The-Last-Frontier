using Sirenix.OdinInspector;
using UnityEngine;

public class CommandGoTo : CommandWorkerComponent
{
	[SerializeField]
	protected Rigidbody2D rb;

	[SerializeField]
	protected float moveSpeed = 0.2f;

	[SerializeField]
	protected float stopDistance = 0.05f;

	[ShowInInspector]
	[ReadOnly]
	protected DirectionsEnum movingDirection;

	[SerializeField]
	protected Vector3 pos = new Vector3(20,0,0);

	internal override void SubscribeToEvents()
	{
		base.SubscribeToEvents();
		eventsProxy.OnGoToCommand += (Command x) => StartMovingToPosition(x.commandVectorValue);
		eventsProxy.OnCommandEnd += () => StopMoving();
		eventsProxy.OnGoToCommand += (Command x) => enabled = true;
	}

	protected void Update()
	{
		var reached = DistanceTracker.IsObjectReachedDestination(transform.position, pos, stopDistance);
		if (reached)
		{
			StopMoving();
			OnPlaceReaching();
		}
	}

	internal void OnPlaceReaching()
	{
		eventsProxy.OnCommandEnd?.Invoke();
	}

	protected void StartMovingToPosition(Vector3 pos)
	{
		this.pos = pos;
		ChooseMovingDirection(pos);
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
		StartMovingToPosition(pos);
	}

	internal override void DisableComponent()
	{
		StopMoving();
	}
}