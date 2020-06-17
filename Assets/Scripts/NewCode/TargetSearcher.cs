using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;

public class TargetSearcher : MonoBehaviour
{
	[SerializeField]
	bool registerTargetsUpdatesReceiversComponents = true;

	[SerializeField]
	bool showSearchRadius;

	[SerializeField]
	float searchRadius = 1;

	[SerializeField]
	float updateTime = 0.5f;

	[SerializeField]
	LayerMask searchingLayers;

	[ShowInInspector]
	[ReadOnly]
	int registeredListenersCount = -1;

	[ShowInInspector]
	[ReadOnly]
	GameObject closestTarget;

	[SerializeField]
	GameObjectUnityEvent onClosestTargetUpdate;
	private ITargetUpdateReceiver[] targetUpdaters;

	private void Awake()
	{
		if(registerTargetsUpdatesReceiversComponents)
		RegisterTargetsUpdateReceivers();
	}

	private void RegisterTargetsUpdateReceivers()
	{
		targetUpdaters = GetComponents<ITargetUpdateReceiver>();
		var listenersCount = 0;
		foreach (var e in targetUpdaters)
		{
			listenersCount++;
			onClosestTargetUpdate.AddListener(e.UpdateTarget);
		}
		registeredListenersCount = listenersCount;
	}

	private void Start()
	{
		StartCoroutine(SearchingRoutine());
	}

	IEnumerator SearchingRoutine()
	{
		while (true)
		{
			closestTarget = GetClosestTarget();
			onClosestTargetUpdate.Invoke(closestTarget);
			yield return new WaitForSeconds(updateTime);
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

	GameObject GetClosestOfTargets(Collider2D[] targets, Transform fromThis)
	{
		GameObject bestTarget = null;
		float closestDistanceSqr = Mathf.Infinity;
		Vector3 currentPosition = fromThis.position;
		foreach (var potentialTarget in targets)
		{
			if (potentialTarget.transform.root == transform) continue;
			Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
			float dSqrToTarget = directionToTarget.sqrMagnitude;
			if (dSqrToTarget < closestDistanceSqr)
			{
				closestDistanceSqr = dSqrToTarget;
				bestTarget = potentialTarget.gameObject;
			}
		}
		return bestTarget;
	}

	private void OnDrawGizmosSelected()
	{
		if (showSearchRadius)
			Gizmos.DrawCube(transform.position, new Vector3(searchRadius, 0.1f, 0));
	}
}
