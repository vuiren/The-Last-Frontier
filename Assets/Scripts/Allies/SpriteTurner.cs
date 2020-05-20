using Sirenix.OdinInspector;
using System;
using UnityEngine;

public class SpriteTurner : AttackingComponent
{
	[SerializeField]
	Rigidbody2D rb;

	[SerializeField]
	SpriteRenderer spriteRenderer;

	[ShowInInspector]
	[ReadOnly]
	bool enemyVisible;

	[ReadOnly]
	[ShowInInspector]
	GameObject enemy;

	internal override void SubscribeToEvents()
	{
		base.SubscribeToEvents();
		eventsProxy.OnClosestTargetUpdate += UpdateEnemy;
	}

	private void UpdateEnemy(GameObject obj)
	{
		enemyVisible = obj != null;
		enemy = obj;
	}

	private void Update()
	{
		if (enemy == null || !enemyVisible || !enemy.gameObject.activeSelf)
			spriteRenderer.flipX = rb.velocity.x <= 0;
		else
		{
			var dif = transform.position.x - enemy.transform.position.x;
			var shootingDirection = dif < 0 ? DirectionsEnum.East : DirectionsEnum.West;
			spriteRenderer.flipX = shootingDirection != DirectionsEnum.East;
		}
	}
}
