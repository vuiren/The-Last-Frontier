using System;
using UnityEngine;

public interface IMovement
{
	void StartMoving(Transform movingPoint);
	void StartMoving(Vector3 movingPoint);
	void StopMoving();
}
