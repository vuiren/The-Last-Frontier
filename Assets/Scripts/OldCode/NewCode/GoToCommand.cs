using UnityEngine;

public class GoToCommand : MonoBehaviour
{
	[SerializeField]
	Rigidbody2D rb;

	[SerializeField]
	NPCInfoHolder NPCInfoHolder;

	[SerializeField]
	float commandStopDistance = 0.02f;

	protected DirectionsEnum movingDirection;

	//[SerializeField]
	protected Vector3 destinationPos = new Vector3(20, 0, 0);

	NPCInfo NPCInfo;

	private void Awake()
	{
		NPCInfo = NPCInfoHolder.NPCInfo;
	}

	protected void Update()
	{
		if (DestinationReached())// reached)
		{
			StopMoving();
		}
	}

	private void FixedUpdate()
	{
		ChooseMovingDirection(destinationPos);
	}

	private bool DestinationReached()
	{
		var reached = DistanceTracker.IsObjectReachedDestination(transform.position, destinationPos, commandStopDistance);// + randomOffset);// stopDistance);
		return reached;
	}

	public void StartMovingToPosition(Command command)
	{
		var pos = command.CommandVectorValue;
		var randomOffset = UnityEngine.Random.Range(-0.1f, 0.1f);
		this.destinationPos = new Vector3(pos.x + randomOffset, pos.y, pos.z);
		ChooseMovingDirection(pos);
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
		movingDirection = dif < 0 ? DirectionsEnum.Right : DirectionsEnum.Left;
		var moveSpeed = NPCInfo.MoveSpeed;
		rb.velocity = new Vector2(movingDirection == DirectionsEnum.Right ? moveSpeed : -moveSpeed, 0);
	}
}
