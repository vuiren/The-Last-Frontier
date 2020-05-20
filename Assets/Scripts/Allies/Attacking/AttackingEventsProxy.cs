using System;
using UnityEngine;

public class AttackingEventsProxy : MonoBehaviour
{
	public Action<GameObject> OnClosestTargetUpdate { get; set; }
	public Action OnReachingEnemy { get; set; }
	public Action OnEnemyGone { get; set; }
	public Action OnEnemyHit { get; set; }

	public float CurReloadingTime { get; set; }
	public float TimeBetweenAttacks { get; set; }
}
