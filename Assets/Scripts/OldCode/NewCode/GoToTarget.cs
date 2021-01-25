using UnityEngine;

public class GoToTarget : MonoBehaviour
{
	[SerializeField]
	NPCInfoHolder NPCInfoHolder;

	NPCInfo NPCInfo;

	private void Awake()
	{
		NPCInfo = NPCInfoHolder.NPCInfo;
	}

	private void FixedUpdate()
	{
		var target = NPCInfoHolder.AttackTarget;
		if (!target) return;
		float distanceToTarget = Vector2.Distance(transform.position, target.transform.position);
		if (distanceToTarget <= NPCInfo.AttackSettings.AttackStartDistance)
		{
			StopMoving();
			return;
		}
		DoGoToTheTarget(target);
	}

	private void StopMoving()
	{
		var rb = NPCInfoHolder.RigidBody;
		rb.velocity = new Vector2();
	}

	private void DoGoToTheTarget(GameObject target)
	{
		var rb = NPCInfoHolder.RigidBody;
		var dif = target.transform.position.x - transform.position.x;
		var moveVector = new Vector2(NPCInfo.MoveSpeed * Time.deltaTime * 60f, 0);
		rb.velocity = dif > 0 ? moveVector : -moveVector;
	}
}
