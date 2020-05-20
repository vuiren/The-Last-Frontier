using System;
using UnityEngine;

public interface IAllyEventsProxy
{
	Action<Transform> OnNoticingEnemy { get; set; }
	Action<Transform> OnEnemyInAttackingRange { get; set; }
	Action OnEnemyOutOfAttackingRange { get; set; }
	Action OnEnemyDeath { get; set; }
}
