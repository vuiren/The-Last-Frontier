using UnityEngine;

public class GoToEnemy : MonoBehaviour
{
	[SerializeField] NPCInfoHolder NPCInfoHolder;
	[SerializeField] float randomSpeedOffset = 0.01f; 

	public void StartMovingToDirection(GameObject target)
	{
		var pos = target.transform.position;
		NPCInfoHolder.DestinationPoint = pos;
		ChooseMovingDirection(NPCInfoHolder.DestinationPoint);
		enabled = true;
	}

	private void Update()
	{
		var target = NPCInfoHolder.AttackTarget;
		if(!target)
		{
			StopMoving(target);
			return;
		}
		NPCInfoHolder.DestinationPoint = target.transform.position;
		var stopDistance = NPCInfoHolder.NPCInfo.AttackSettings.AttackStartDistance;
		if (Vector3.Distance(transform.position, NPCInfoHolder.DestinationPoint) < stopDistance)
		{
			StopMoving(target);
		}
		else
		{
			ChooseMovingDirection(NPCInfoHolder.DestinationPoint);
		}
	}

	public void StopMoving(GameObject target)
	{
		var rb = NPCInfoHolder.RigidBody;
		rb.velocity = new Vector2(0, rb.velocity.y);
		enabled = target;
		//enabled = false;
	}

	private void ChooseMovingDirection(Vector3 destinationPoint)
	{
		var rb = NPCInfoHolder.RigidBody;
		var moveSpeed = NPCInfoHolder.NPCInfo.MoveSpeed;
		var moveDirectionX = Mathf.Sign(destinationPoint.x - transform.position.x);
		rb.velocity = new Vector2(moveDirectionX * moveSpeed, rb.velocity.y);
	}
}
