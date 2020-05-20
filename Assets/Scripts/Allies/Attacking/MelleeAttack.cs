using Sirenix.OdinInspector;
using System;
using UnityEngine;

public class MelleeAttack : AttackingComponent
{
	[SerializeField]
	int damageCount = 1;

	[ReadOnly]
	[ShowInInspector]
	HealthEventsProxy target;

	internal override void SubscribeToEvents()
	{
		base.SubscribeToEvents();
		eventsProxy.OnClosestTargetUpdate += SetTarget;
		eventsProxy.OnEnemyHit += DoDamageTarget;
		eventsProxy.OnEnemyGone += () => SetTarget(null);
	}

	private void SetTarget(GameObject obj)
	{
		if (!obj) return;
		target = obj.GetComponent<HealthEventsProxy>();
		if(target == null)
		{
			return;
			//throw new Exception("TARGET GOT NO HEALTH");
		}
	}

	private void DoDamageTarget()
	{
		if (target == null) return;
		target.OnTakingDamage?.Invoke(damageCount);
	}
}
