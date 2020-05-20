using UnityEngine;

public interface ITargetAttacker
{
	void StartAttackingTarget(Transform target);
	void StopAttacking();
}
