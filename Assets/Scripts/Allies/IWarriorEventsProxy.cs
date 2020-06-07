using System;
using UnityEngine;

public interface IWarriorEventsProxy
{
	Action<Transform> OnNoticingEnemy { get; set; }
	Action OnEnemyDeath { get; set; }
	//Action OnEnemyOutOfAttackingRange { get; set; }
	//	Action<Transform> OnEnemyInAttackingRange { get; set; }
	Action OnReachingDestinationPoint { get; set; }
	Action<int> OnAttackHit { get; set; }
	Action<int> OnTakingDamage { get; set; }
	Action<int> OnHealthChanged { get; set; }
	Action OnDeath { get; set; }
	Action<Command> OnPlayerCommandSet { get; set; }
	Action<Command> OnPlayerCommandEnd { get; set; }
	void UnsubscribeAll();
}
