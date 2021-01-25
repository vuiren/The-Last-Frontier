using Sirenix.OdinInspector;
using System;
using UnityEngine;

[Serializable]
public class AttackSettings
{
	[SerializeField] private int damageCount = 1;
	[SerializeField] private float timeBetweenAttacks = 1;
	[SerializeField] private float enemyNoticeDistance;
	[SerializeField] private AudioClip attackSound;
	[SerializeField] protected float attackStartDistance = 1f;
	[SerializeField] protected AttackType attackType;

	[ShowIf("attackType", AttackType.Range)]
	[SerializeField] private GameObject projectilePrefab;

	[ShowIf("attackType", AttackType.Range)]
	[SerializeField] private int projectilesCount = 1;


	[SerializeField]
	[ReadOnly]
	private float damagePerSecond;

	public float AttackStartDistance => attackStartDistance;
	public float TimeBetweenAttacks => timeBetweenAttacks;
	public int DamageCount => damageCount;
	public AudioClip AttackSound => attackSound;
	public GameObject ProjectilePrefab => projectilePrefab;
	public float EnemyNoticeDistance => enemyNoticeDistance;

	[Button]
	private void CalculateDamage()
	{
		var projectCount = projectilesCount == 0 ? 1 : projectilesCount;
		damagePerSecond = damageCount * projectCount * (1f / timeBetweenAttacks);
	}
}
