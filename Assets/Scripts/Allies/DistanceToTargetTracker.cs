using Sirenix.OdinInspector;
using System;
using UnityEngine;

public class DistanceToTargetTracker : WarriorComponent, IDistanceWatcher
{
	[SerializeField]
	float attackStartDistance = 0.2f;

	[SerializeField]
	float pointStopDistance = 0.1f;

	[ReadOnly]
	[ShowInInspector]
	Transform target;

	Vector3 pointOfDestination;

	public Action OnEnemyInAttackingRange { get; set; }
	public Action OnEnemyOutsideAttackingRange { get; set; }

	bool EnemyInAttackingRange { get; set; }
	bool EnemyWasReached { get; set; }
	bool TrackDistance { get; set; }
	bool ExecutingPlayerCommand { get; set; }
	Command command;

	private void Update()
	{
		if (TrackDistance)
		{
			if (!ExecutingPlayerCommand)
				CheckDistanceToAnEnemy();
			else
				CheckDistanceToPoint();
		}
	}

	private void CheckDistanceToPoint()
	{
		var pointInReachingRange = Math.Abs(transform.position.x - pointOfDestination.x) <= pointStopDistance;

		if(pointInReachingRange)
		{
	//		eventsProxy.OnPlayerCommandEnd?.Invoke(command);
			StopTrackingDistanceToTarget();
		}
	}

	private void CheckDistanceToAnEnemy()
	{
		if (target == null)
		{
			StopTrackingDistanceToTarget();
			return;
		}
		EnemyInAttackingRange = Math.Abs(transform.position.x - target.position.x) <= attackStartDistance;

		if (EnemyInAttackingRange && !EnemyWasReached)
		{
			OnEnemyInAttackingRange?.Invoke();
			EnemyWasReached = true;
			//eventsProxy.OnReachingDestinationPoint?.Invoke();
			Debug.Log("Enemy In Attacking Range");
			StopTrackingDistanceToTarget();
			return;
		}
	}

	public void StartTrackingDistanceToTarget(Transform target)
	{
		this.target = target;
		TrackDistance = true;
	}

	public void StopTrackingDistanceToTarget()
	{
		target = null;
		TrackDistance = false;
		EnemyWasReached = false;
		pointOfDestination = transform.position;
		ExecutingPlayerCommand = false;
	}

	private void StartTrackingDistanceToPoint(Vector3 point)
	{
		ExecutingPlayerCommand = true;
		pointOfDestination = point;
		TrackDistance = true;
	}

	protected override void SubscribeToEventsProxy()
	{
		//eventsProxy.OnNoticingEnemy += StartTrackingDistanceToTarget;
		//eventsProxy.OnEnemyDeath += StopTrackingDistanceToTarget;
		//eventsProxy.OnPlayerCommandSet += SetCommand;
	}

	private void SetCommand(Command obj)
	{
		command = obj;
		switch (obj.commandType)
		{
			case CommandsEnum.GoTo:
				StartTrackingDistanceToPoint(obj.commandVectorValue);
				break;
		}
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