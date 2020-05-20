using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;

public class HealingTargetSearching : MedicComponent
{
	[SerializeField]
	float searchRadius = 1;

	[SerializeField]
	float updateTime = 2f;

	[SerializeField]
	LayerMask searchingLayers;

	[ShowInInspector]
	[ReadOnly]
	Transform closestTarget;

	Coroutine coroutine;
	string prevTargetName = "";

	private void Start()
	{
		coroutine = StartCoroutine(SearchingRoutine());
	}

	IEnumerator SearchingRoutine()
	{
		while (true)
		{
			if (closestTarget == null || closestTarget.gameObject.activeSelf)
			{
				eventsProxy.OnHealTargetGone?.Invoke();
			}

			closestTarget = GetClosestTarget();

			if (closestTarget != null)
			{
				eventsProxy.OnClosestHealTargetUpdate?.Invoke(closestTarget);
			}
			yield return new WaitForSeconds(updateTime);
			prevTargetName = closestTarget == null ? "" : closestTarget.name;
		}
	}

	private Transform GetClosestTarget()
	{
		var pt = Physics2D.OverlapBoxAll(transform.position, new Vector2(searchRadius, searchRadius), 0, searchingLayers);
		if (pt.Length > 0)
		{
			return GetClosestOfTargets(pt, transform);
		}
		return null;
	}

	Transform GetClosestOfTargets(Collider2D[] enemies, Transform fromThis)
	{
		Transform bestTarget = null;
		float closestDistanceSqr = Mathf.Infinity;
		Vector3 currentPosition = fromThis.position;
		foreach (var potentialTarget in enemies)
		{
			if (transform.name == potentialTarget.name && Vector3.Distance(transform.position, potentialTarget.transform.position) <= 0.002) continue;
			var health = potentialTarget.transform.GetComponent<HealthEventsProxy>();
			if (!health.RequiredHealing) continue;
			Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
			float dSqrToTarget = directionToTarget.sqrMagnitude;
			if (dSqrToTarget < closestDistanceSqr)
			{
				closestDistanceSqr = dSqrToTarget;
				bestTarget = potentialTarget.transform;
			}
		}
		return bestTarget;
	}

	internal override void EnableComponent()
	{
		if (coroutine != null)
			coroutine = StartCoroutine(SearchingRoutine());
	}

	internal override void DisableComponent()
	{
		if (coroutine != null)
			StopCoroutine(coroutine);
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.DrawCube(transform.position, new Vector3(searchRadius, 0.1f, 0));
	}
}
