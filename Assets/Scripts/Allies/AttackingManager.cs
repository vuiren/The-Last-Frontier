using System;
using System.Collections;
using UnityEngine;

public enum AttackStates { }

public class AttackingManager : WarriorComponent
{
	[SerializeField]
	int damageCount;

	[SerializeField]
	float timeBetweenAttacks;

	bool attacking;

	bool readyToAttack;

	float reloadTime;

	bool waitingForAttack;

	protected override void SubscribeToEventsProxy()
	{
		//eventsProxy.OnNoticingEnemy += StartTrackingDistance;
	//	eventsProxy.OnEnemyDeath += StopAttack;
	}

	private void StartTrackingDistance(Transform obj)
	{
		throw new NotImplementedException();
	}

	private void Update()
	{
		if (!attacking) return;
		if(readyToAttack)
		{
			Attack();
		}
		else
		{
			Reload();
		}
	}

	private void Reload()
	{
		reloadTime -= Time.deltaTime;
		readyToAttack = reloadTime <= 0;
	}

	private void Attack()
	{
	//	eventsProxy.OnAttackHit?.Invoke(damageCount);
		readyToAttack = false;
		reloadTime = timeBetweenAttacks;
	}

	private void StopAttack()
	{
		attacking = false;
	}

	private void StartAttack(Transform obj)
	{
		attacking = obj != null;
	}

	internal override void EnableComponent()
	{
		throw new NotImplementedException();
	}

	internal override void DisableComponent()
	{
		throw new NotImplementedException();
	}
}
