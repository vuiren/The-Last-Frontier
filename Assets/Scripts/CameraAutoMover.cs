using UnityEngine;

public class CameraAutoMover : MonoBehaviour
{
	[SerializeField]
	Rigidbody rb;

	[SerializeField]
	float moveSpeed = 0.2f;

	private void Awake()
	{
		rb.velocity = new Vector2(moveSpeed, 0);
	}
}
