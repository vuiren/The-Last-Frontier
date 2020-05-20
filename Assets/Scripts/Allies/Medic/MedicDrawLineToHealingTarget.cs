using Sirenix.OdinInspector;
using System;
using UnityEngine;

public class MedicDrawLineToHealingTarget : MedicComponent
{
	[SerializeField]
	LineRenderer lineRenderer;

	[ShowInInspector]
	[ReadOnly]
	Transform target;
	internal override void SubscribeToEvents()
	{
		base.SubscribeToEvents();
		eventsProxy.OnClosestHealTargetUpdate += UpdateTarget;
		eventsProxy.OnHealTargetGone += StopLine;
	}

	private void StopLine()
	{
		lineRenderer.SetPositions(new Vector3[2] { new Vector3(), new Vector3() });
		target = null;
	}

	private void UpdateTarget(Transform obj)
	{
		target = obj;
	}

	private void Update()
	{
		if (target == null) return;
		DrawLine(target);
	}

	private void DrawLine(Transform obj)
	{
		Vector3[] points = new Vector3[2] { transform.position + new Vector3(0, 0.05f, 0), obj.position + new Vector3(0, 0.05f, 0) };
		lineRenderer.SetPositions(points);
	}
}
