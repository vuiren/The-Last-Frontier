using UnityEngine;

public class MoveCameraToStartOnTrigger : MonoBehaviour
{
	[SerializeField]
	Transform movePoint;

	private void OnTriggerEnter(Collider collision)
	{
		if (!collision.CompareTag("MainCamera")) return;
		collision.transform.position = movePoint.position;
	}
}
