using Sirenix.OdinInspector;
using System;
using UnityEngine;

public class SpriteTurner : MonoBehaviour, ITargetUpdateReceiver
{
	[SerializeField]
	Rigidbody2D rb;

	[SerializeField]
	SpriteRenderer spriteRenderer;

	[ReadOnly]
	[ShowInInspector]
	GameObject target;

	public void UpdateTarget(GameObject obj)
	{
		target = obj;
	}

	private void Update()
	{
		if (!target)
			TurnBySpeed();
		else
			TurnByEnemyPosition();
	}

	private void TurnByEnemyPosition()
	{
		var dif = target.transform.position.x - transform.position.x;
		spriteRenderer.flipX = dif < 0;//shootingDirection != DirectionsEnum.East;
	}

	private void TurnBySpeed()
	{
		var x = rb.velocity.x;
		if (Mathf.Approximately(x, 0)) return;
		spriteRenderer.flipX = x < 0;
	}
}
