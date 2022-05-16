using System.Collections.Generic;
using UnityEngine;

public class AimObjectsAtTarget
{
	[SerializeField]
	Vector3 aimingOffset;

	public void Aim(GameObject target, List<Transform> objectsParents)
	{
		foreach (var e in objectsParents)
		{
			for (int i = 0; i < e.transform.childCount; i++)
			{
				var child = e.transform.GetChild(i);
				child.transform.right = target.transform.position + aimingOffset - child.position;
			}
		}
	}
}
