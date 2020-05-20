using System;
using UnityEngine;

public interface IDistanceWatcher
{
	Action OnEnemyInAttackingRange { get; set; } 
	Action OnEnemyOutsideAttackingRange { get; set; }
	void StartTrackingDistanceToTarget(Transform target);
	void StopTrackingDistanceToTarget();
}
