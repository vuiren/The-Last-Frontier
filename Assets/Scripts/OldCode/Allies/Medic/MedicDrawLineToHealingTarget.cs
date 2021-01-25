using Sirenix.OdinInspector;
using System;
using UnityEngine;

public class MedicDrawLineToHealingTarget : MonoBehaviour
{
	[SerializeField]
	NPCInfoHolder NPCInfoHolder;

	[SerializeField]
	Transform rayStartTransform;

	[SerializeField]
	Vector3 healingRayTargetOffset;

	[SerializeField]
	LineRenderer lineRenderer;

	private void StopLine()
	{
		lineRenderer.SetPositions(new Vector3[2] { new Vector3(), new Vector3() });
	}

	private void Update()
	{
		var target = NPCInfoHolder.AttackTarget;
		var healingRequired = TargetRequiringHealing(target);
		if (!target || !healingRequired)
		{
			StopLine();
			return;
		}
		if (healingRequired)
		{
			DrawLineToTarget(target);
		}
	}

	private bool TargetRequiringHealing(GameObject target)
	{
		if (!target) return false;
		var health = target.transform.GetComponentInChildren<IHealthController>();
		if (health == null) return false;
		return health.HealingRequired();
	}

	[Button]
	private void DrawLineToTarget(GameObject obj)
	{
		var objPos = obj.transform.position;
		Vector3 rayStart = rayStartTransform.position;
		Vector3 rayEnd = objPos + healingRayTargetOffset;

		Vector3[] points = new Vector3[2] { rayStart, rayEnd };
		lineRenderer.SetPositions(points);
	}
}
