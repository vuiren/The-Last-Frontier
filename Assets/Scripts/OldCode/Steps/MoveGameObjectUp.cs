using UnityEngine;

public class MoveGameObjectUp : MonoBehaviour
{
	[SerializeField] Vector2 pushForce = new Vector2(0, 1.1f);
	[SerializeField] DirectionsEnum reactToDirection;

	private void OnTriggerStay2D(Collider2D collision)
	{
		var rb = collision.transform.parent.GetComponentInChildren<Rigidbody2D>();
		var velocity = rb.velocity;
		var movingSide = velocity.x > 0 ? DirectionsEnum.Right : DirectionsEnum.Left;
		if (movingSide == reactToDirection)
			rb.AddForce(pushForce);
	}
}
