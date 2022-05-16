using UnityEngine;

public class StickToTheGround : MonoBehaviour
{
	[SerializeField]
	bool update = true;

	[SerializeField] Transform offsetPoint;
	[SerializeField] GameObject objectToStick;

	[SerializeField]
	Vector3 startOffset = new Vector3(0, 1);

	[SerializeField]
	Vector3 endOffset = new Vector3(0, -1);
	//	List<Transform> stickPoints;

	[SerializeField]
	LayerMask earthLayer;

	private void Start()
	{
		if (!update)
			StickIt(objectToStick.transform.position, new Vector3(0, 1));
		enabled = update;
	}

	void LateUpdate()
	{
		StickIt(objectToStick.transform.position, startOffset);
	}

	private void StickIt(Vector3 point, Vector3 startOffset)
	{
		Vector3 start = offsetPoint.position + startOffset; //point + startOffset;
		Vector3 end = point + startOffset + endOffset;
		var hit = Physics2D.Linecast(start, end, earthLayer);
		if (hit)
		{
			objectToStick.transform.position = hit.point;
			objectToStick.transform.rotation = Quaternion.FromToRotation(objectToStick.transform.up, hit.normal) * objectToStick.transform.rotation;
		}
	}

	private void OnDrawGizmosSelected()
	{
		var point = offsetPoint.position; //objectToStick.transform.position;
		Vector3 start = point + startOffset;
		Vector3 end = point + startOffset + endOffset;
		Gizmos.DrawLine(start, end);

	}
}
