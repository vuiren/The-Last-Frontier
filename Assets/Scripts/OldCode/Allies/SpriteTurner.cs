using Sirenix.OdinInspector;
using System;
using UnityEngine;

public class SpriteTurner : MonoBehaviour, INPCInfoReader
{
	[SerializeField] [ReadOnly] NPCInfoHolder NPCInfoHolder;
	[SerializeField] SpriteRenderer spriteRenderer;

	private void Update()
	{
		var target = NPCInfoHolder.AttackTarget;
		if (!target)
			TurnByMovingDirection();
		//TurnBySpeed(NPCInfoHolder.RigidBody);
		else
			TurnByEnemyPosition(target);
	}

	private void TurnByEnemyPosition(GameObject target)
	{
		var dif = target.transform.position.x - transform.position.x;
		spriteRenderer.flipX = dif < 0;
	}

	private void TurnByMovingDirection()
	{
		var movingDirection = NPCInfoHolder.MovingDirection;
		if (movingDirection == MovingsEnum.Standing) return;
		spriteRenderer.flipX = movingDirection == MovingsEnum.GoingLeft;
	}

	private void TurnBySpeed(Rigidbody2D rb)
	{
		var x = rb.velocity.x;
		var delta = 0.05f;
		if (Mathf.Abs(x) <= delta)  return;
		spriteRenderer.flipX = x < 0;
	}

	public void SetNPCInfoHandler(NPCInfoHolder NPCInfoHolder)
	{
		this.NPCInfoHolder = NPCInfoHolder;
	}
}
