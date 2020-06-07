using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turner : WarriorComponent
{
	[SerializeField]
	SpriteRenderer spriteRenderer;

	protected override void SubscribeToEventsProxy()
	{
		eventsProxy.OnNoticingEnemy += TurnToEnemy;
	}

	internal override void DisableComponent()
	{
		throw new NotImplementedException();
	}

	internal override void EnableComponent()
	{
		throw new NotImplementedException();
	}

	private void TurnToEnemy(Transform obj)
	{
		if (obj == null || this == null)
		{
			spriteRenderer.flipX = false;
			return;
		}
		var difX = transform.position.x - obj.position.x;
		spriteRenderer.flipX = difX >= 0;
	}
}