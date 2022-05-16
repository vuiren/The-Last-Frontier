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

	[SerializeField] private GameObject projectilePrefab;

	[SerializeField] private int projectilesCount = 1;


	[SerializeField]
	private float damagePerSecond;

	public float AttackStartDistance => attackStartDistance;
	public float TimeBetweenAttacks => timeBetweenAttacks;
	public int DamageCount => damageCount;
	public AudioClip AttackSound => attackSound;
	public GameObject ProjectilePrefab => projectilePrefab;
	public float EnemyNoticeDistance => enemyNoticeDistance;

	private void CalculateDamage()
	{
		var projectCount = projectilesCount == 0 ? 1 : projectilesCount;
		damagePerSecond = damageCount * projectCount * (1f / timeBetweenAttacks);
	}
}
