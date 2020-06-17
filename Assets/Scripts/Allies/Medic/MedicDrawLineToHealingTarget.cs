using Sirenix.OdinInspector;
using System;
using UnityEngine;

public class MedicDrawLineToHealingTarget : MonoBehaviour, ITargetUpdateReceiver
{
	[SerializeField]
	Transform rayStartTransform;

	[SerializeField]
	Vector3 healingRayTargetOffset;

	[SerializeField]
	LineRenderer lineRenderer;

	[ShowInInspector]
	[ReadOnly]
	GameObject target;

	private void StopLine()
	{
		lineRenderer.SetPositions(new Vector3[2] { new Vector3(), new Vector3() });
	}

	public void UpdateTarget(GameObject obj)
	{
		target = obj;
	}

	private void Update()
	{
		var healingRequired = TargetRequiringHealing();

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

	private bool TargetRequiringHealing()
	{
		if (!target) return false;
		var health = target.GetComponent<IHealable>();
		if (health == null) return false;
		return health.HealingRequired();
	}

	private void DrawLineToTarget(GameObject obj)
	{
		var objPos = obj.transform.position;
		Vector3 rayStart = rayStartTransform.position;
		Vector3 rayEnd = objPos + healingRayTargetOffset;

		Vector3[] points = new Vector3[2] { rayStart, rayEnd };
		lineRenderer.SetPositions(points);
	}
}
