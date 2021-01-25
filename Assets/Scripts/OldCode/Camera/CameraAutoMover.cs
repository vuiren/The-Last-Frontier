using UnityEngine;

public class CameraAutoMover : MonoBehaviour
{
	[SerializeField]
	Rigidbody rb;

	[SerializeField]
	float moveSpeed = 0.2f;

	[SerializeField]
	Transform moveCameraBackPoint;

	private void Awake()
	{
		rb.velocity = new Vector2(moveSpeed, 0);
	}

	private void Update()
	{
		
	}
}
