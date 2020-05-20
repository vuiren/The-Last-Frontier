using System;
using UnityEngine;

public class WarriorEventsProxy : MonoBehaviour, IWarriorEventsProxy
{
	public Action<Transform> OnNoticingEnemy { get; set; }
	public Action OnEnemyDeath { get; set; }
	public Action<int> OnAttackHit { get; set; }
	public Action<int> OnTakingDamage { get; set; }
	public Action<int> OnHealthChanged { get; set; }
	public Action OnDeath { get; set; }
	public Action<Command> OnPlayerCommandSet { get; set; }
	public Action<Command> OnPlayerCommandEnd { get; set; }
	public Action OnReachingDestinationPoint { get; set; }

	public void UnsubscribeAll()
	{
		OnNoticingEnemy = null;
		OnEnemyDeath = null;
		OnAttackHit = null;
		OnReachingDestinationPoint = null;
	}
}
