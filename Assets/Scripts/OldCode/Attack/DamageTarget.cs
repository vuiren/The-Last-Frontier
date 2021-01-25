using Sirenix.OdinInspector;
using UnityEngine;

public class DamageTarget : MonoBehaviour
{
	[ReadOnly]
	[ShowInInspector]
	IHealthController damageableTarget;

	public void DoDamageTarget(GameObject target, int damageCount)
	{
		UpdateTarget(target);
		if (damageableTarget == null) return;
		damageableTarget.TakeDamage(damageCount);
	}

	public void UpdateTarget(GameObject target)
	{
		if (!target)
		{
			damageableTarget = null;
			return;
		}
		damageableTarget = target.transform.parent.GetComponentInChildren<IHealthController>();
	}
}