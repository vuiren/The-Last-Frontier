using UnityEngine;

public class SnapGameObject : MonoBehaviour
{
	[SerializeField]
	Transform objectToSnap;

	[SerializeField]
	float cellSize;

	private void LateUpdate()
	{
		var position = objectToSnap.position;
		var xAmount = (int)(position.x / cellSize);
		var yAmount = (int)(position.y / cellSize);
		var newPosition = new Vector2(xAmount, yAmount) * cellSize;
		objectToSnap.position = newPosition;
	}
}
