using Sirenix.OdinInspector;
using UnityEngine;

public class GoToCommand : MonoBehaviour
{
	[SerializeField]
	Rigidbody2D rb;

	[SerializeField]
	float moveSpeed = 0.2f;

	[SerializeField]
	float stopDistance = 0.05f;

	[ShowInInspector]
	[ReadOnly]
	protected DirectionsEnum movingDirection;

	[SerializeField]
	protected Vector3 pos = new Vector3(20, 0, 0);

	protected void Update()
	{
		var reached = DistanceTracker.IsObjectReachedDestination(transform.position, pos, stopDistance);
		if (reached)
		{
			StopMoving();
		}
	}

	public void StartMovingToPosition(Command command)
	{
		var pos = command.commandVectorValue;
		this.pos = pos;
		ChooseMovingDirection(pos);
		rb.velocity = new Vector2(movingDirection == DirectionsEnum.East ? moveSpeed : -moveSpeed, 0);
		enabled = true;
	}

	protected void StopMoving()
	{
		enabled = false;
		rb.velocity = new Vector2();
	}

	protected void ChooseMovingDirection(Vector3 targetPos)
	{
		var dif = transform.position.x - targetPos.x;
		movingDirection = dif < 0 ? DirectionsEnum.East : DirectionsEnum.West;
	}
}
