using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;

public class AttackingTargetSearcher : AttackingComponent
{
	[SerializeField]
	float searchRadius = 1;

	[SerializeField]
	float updateTime = 0.5f;

	[SerializeField]
	LayerMask searchingLayers;

	[ShowInInspector]
	[ReadOnly]
	GameObject closestTarget;

	Coroutine coroutine;
	string prevTargetName = "";

	IEnumerator SearchingRoutine()
	{
		while (true)
		{
			if (closestTarget != null && !closestTarget.gameObject.activeSelf)
			{
				eventsProxy.OnEnemyGone?.Invoke();
			}

			closestTarget = GetClosestTarget();

			if (closestTarget != null)
			{
				eventsProxy.OnClosestTargetUpdate?.Invoke(closestTarget);
			}
			yield return new WaitForSeconds(updateTime);
			prevTargetName = closestTarget == null ? "" : closestTarget.name;
		}
	}

	private GameObject GetClosestTarget()
	{
		var pt = Physics2D.OverlapBoxAll(transform.position, new Vector2(searchRadius, searchRadius), 0, searchingLayers);
		if (pt.Length > 0)
		{
			return GetClosestOfTargets(pt, transform);
		}
		return null;
	}

	GameObject GetClosestOfTargets(Collider2D[] enemies, Transform fromThis)
	{
		Transform bestTarget = null;
		float closestDistanceSqr = Mathf.Infinity;
		Vector3 currentPosition = fromThis.position;
		foreach (var potentialTarget in enemies)
		{
			Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
			float dSqrToTarget = directionToTarget.sqrMagnitude;
			if (dSqrToTarget < closestDistanceSqr)
			{
				closestDistanceSqr = dSqrToTarget;
				bestTarget = potentialTarget.transform;
			}
		}
		return bestTarget.gameObject;
	}

	internal override void EnableComponent()
	{
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
