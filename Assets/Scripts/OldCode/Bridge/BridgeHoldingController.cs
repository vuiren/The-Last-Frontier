using System;
using System.Collections.Generic;
using UnityEngine;

public class BridgeHoldingController : MonoBehaviour
{
	[SerializeField]
	Transform raycastStartPoint;

	[SerializeField]
	float raycastLength;

	[SerializeField]
	LayerMask stairsLayers;

	[SerializeField]
	List<BridgeHoldingController> connectedBridges;

	public Action OnStateChanged { get; set; }

	private readonly Vector2[] sides = new[] { new Vector2(-1, 0), new Vector2(1, 0), new Vector2(0, 1), new Vector2(0, -1) };
	private void Start()
	{
		
	}

	private void OnDrawGizmosSelected()
	{
		if (raycastStartPoint == null) return;
		var pos = raycastStartPoint.position;
		foreach(var e in sides)
		{
			Gizmos.DrawLine(pos, pos + new Vector3(e.x, e.y)*raycastLength);
		}
	}

	private bool Grounded()
	{
		return true;
	}

	private void LookForBridgeParts()
	{
		connectedBridges = new List<BridgeHoldingController>();
		var pos = raycastStartPoint.position;
		foreach (var e in sides)
		{
			var hit = Physics2D.Linecast(pos, pos + new Vector3(e.x, e.y)*raycastLength, stairsLayers);
			if(hit)
			{
				connectedBridges.Add(hit.transform.GetComponentInChildren<BridgeHoldingController>());
			}
		}
	}
}
