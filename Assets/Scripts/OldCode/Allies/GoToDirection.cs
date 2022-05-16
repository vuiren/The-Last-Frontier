using UnityEngine;

public class GoToDirection : MonoBehaviour
{
	[SerializeField] NPCInfoHolder NPCInfoHolder;

	[SerializeField]
	float stopDistance = 0.02f;

	private void Start()
	{
		NPCInfoHolder.DestinationPoint = transform.position;
	}

	public void StartMovingToDirection(Command command)
	{
		var pos = command.CommandVectorValue;
		StartMoving(pos);
	}

	private void StartMoving(Vector3 pos)
	{
		var randomOffset = Random.Range(-0.1f, 0.1f);
		var destinationPoint = new Vector3(pos.x + randomOffset, pos.y, transform.position.z);
		ChooseMovingDirection(destinationPoint);
		NPCInfoHolder.DestinationPoint = destinationPoint;
		enabled = true;
	}

	public void GoToEnemy(GameObject target)
	{
		//stopDistance = NPCInfoHolder.NPCInfo.RangeAttackStartDistance;
		var pos = target.transform.position;
		StartMoving(pos);
	}

	private void Update()
	{
		var destinationPoint = NPCInfoHolder.DestinationPoint;
		var dif = Mathf.Abs(NPCInfoHolder.transform.position.x - destinationPoint.x);
		if(dif < stopDistance)
		{
			StopMoving();
		}
	}

	private void FixedUpdate()
	{
		var destinationPoint = NPCInfoHolder.DestinationPoint;
		ChooseMovingDirection(destinationPoint);
	}

	public void StopMoving()
	{
		var rb = NPCInfoHolder.RigidBody;
		rb.velocity = new Vector2(0, rb.velocity.y);
		enabled = false;
	}

	private void ChooseMovingDirection(Vector3 destinationPoint)
	{
		var rb = NPCInfoHolder.RigidBody;
		var moveSpeed = NPCInfoHolder.NPCInfo.MoveSpeed;
		var moveDirectionX = Mathf.Sign(destinationPoint.x - NPCInfoHolder.transform.position.x);
		rb.velocity = new Vector2(moveDirectionX * moveSpeed, rb.velocity.y);
	}
}
