using UnityEngine;

public class BulletMover : MonoBehaviour
{
	[SerializeField]
	Rigidbody2D rb;

	[SerializeField]
	float flySpeed = 1f;

	private void Awake()
	{
		rb.velocity = transform.right * flySpeed;
	}
}
