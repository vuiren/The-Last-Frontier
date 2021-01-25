using System;
using UnityEngine;

public static class DistanceTracker
{
	public static bool IsObjectReachedDestination(Vector3 objectPos, Vector3 targetPos, float stopDistance)
	{
		var distance = Math.Abs(objectPos.x - targetPos.x);
		return distance <= stopDistance;
	}
}
