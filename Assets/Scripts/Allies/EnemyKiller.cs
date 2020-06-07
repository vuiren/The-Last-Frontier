using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKiller : AllyComponent
{
	Transform target;

	protected override void SubscribeToEventsProxy()
	{
		eventsProxy.OnNoticingEnemy += SetTarget;
		eventsProxy.OnAttackHit += KillTarget;
	}

	internal override void DisableComponent()
	{
		throw new NotImplementedException();
	}

	internal override void EnableComponent()
	{
		throw new NotImplementedException();
	}

	private void KillTarget(int obj)
	{
		if (target == null) return;
		Destroy(target.gameObject);
		eventsProxy.OnEnemyDeath?.Invoke();
	}

	private void SetTarget(Transform obj)
	{
		target = obj;	
	}
}
