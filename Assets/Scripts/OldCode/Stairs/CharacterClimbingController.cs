using Sirenix.OdinInspector;
using UnityEngine;

struct RaycastOrigins
{
	public Vector2 topLeft, topRight;
	public Vector2 bottomLeft, bottomRight;
}

public enum MovingsEnum { Standing, GoingLeft, GoingRight}
public class CharacterClimbingController : MonoBehaviour, INPCInfoReader
{
	[SerializeField] [ReadOnly]
	NPCInfoHolder NPCInfoHolder;

	[SerializeField]
	Collider2D collider;

	[SerializeField]
	float skinWidth;

	[SerializeField]
	Vector2 size;

	[SerializeField]
	float pushUpForce = 12f;

	[SerializeField]
	LayerMask climbingLayers;

	[SerializeField]
	float gizmosRadius = 0.05f;

	RaycastOrigins raycastOrigins;

	public void SetNPCInfoHandler(NPCInfoHolder NPCInfoHolder)
	{
		this.NPCInfoHolder = NPCInfoHolder;
	}

	private void Start()
	{
		SetRaycastOrigins();
	}

	[Button]
	private void SetRaycastOrigins()
	{
		Bounds bounds = collider.bounds;
		bounds.Expand(skinWidth * -2);

		raycastOrigins.bottomLeft = new Vector2(bounds.min.x, bounds.min.y);
		raycastOrigins.bottomRight = new Vector2(bounds.max.x, bounds.min.y);
		raycastOrigins.topLeft = new Vector2(bounds.min.x, bounds.max.y);
		raycastOrigins.topRight = new Vector2(bounds.max.x, bounds.max.y);
	}

	private void Update()
	{
		LookForStairs();
	}

	private void LookForStairs()
	{
		SetRaycastOrigins();
		var movingDirection = NPCInfoHolder.MovingDirection;
		if (movingDirection == MovingsEnum.Standing)
		{
			//	StandStill();
			return;
		}
		//var hit = Physics2D.OverlapBox(raycastStart.position, size, 0, climbingLayers); 

		var hit = GetHit(movingDirection);

		if (hit)
		{
			float slopeAngle = Vector2.Angle(hit.normal, Vector2.up);

			var veloctiy = NPCInfoHolder.RigidBody.velocity;
			//	AppyForce(pointX);
			ClimbSlope(ref veloctiy, slopeAngle);
			NPCInfoHolder.RigidBody.velocity = veloctiy;
		}
	}

	private void StandStill()
	{
		NPCInfoHolder.RigidBody.velocity = new Vector2(0f, 0f);
	}

	private RaycastHit2D GetHit(MovingsEnum movingDirection)
	{
		if (movingDirection == MovingsEnum.GoingLeft)
		{
			return Physics2D.Raycast(raycastOrigins.bottomLeft, -Vector2.right * gizmosRadius, gizmosRadius, climbingLayers);
		}

		if (movingDirection == MovingsEnum.GoingRight)
		{
			return Physics2D.Raycast(raycastOrigins.bottomRight, Vector2.right, gizmosRadius, climbingLayers);
		}

		return new RaycastHit2D();
	}

	void ClimbSlope(ref Vector2 velocity, float slopeAngle)
	{
		float moveDistance = Mathf.Abs(velocity.x);
		float climbVelocityY = Mathf.Sin(slopeAngle * Mathf.Deg2Rad) * moveDistance;

		if (velocity.y <= climbVelocityY)
		{
			velocity.y = climbVelocityY;
			velocity.x = Mathf.Cos(slopeAngle * Mathf.Deg2Rad) * moveDistance * Mathf.Sign(velocity.x);
		}
	}

	private void AppyForce(float hitX)
	{
		//if (!ShouldApplyForce(hitX)) return;
		NPCInfoHolder.RigidBody.AddForce(new Vector2(0, pushUpForce));
	}

	private bool ShouldApplyForce(float hitX)
	{
		var posX = NPCInfoHolder.transform.position.x;
		var movingDirection = NPCInfoHolder.MovingDirection;

		var cond1 = hitX > posX && movingDirection == MovingsEnum.GoingRight;
		var cond2 = hitX < posX && movingDirection == MovingsEnum.GoingLeft;
		//Debug.Log(cond1 || cond2);
		return cond1 || cond2;
	}

	private void OnDrawGizmosSelected()
	{
	//	Gizmos.DrawWireSphere(raycastOrigins.bottomLeft, gizmosRadius);
	//	Gizmos.DrawWireSphere(raycastOrigins.bottomRight, gizmosRadius);
		//Gizmos.DrawWireSphere(raycastOrigins.topLeft, gizmosRadius);
		//Gizmos.DrawWireSphere(raycastOrigins.topRight, gizmosRadius);

		Gizmos.color = Color.red;
		Gizmos.DrawLine(raycastOrigins.bottomLeft, raycastOrigins.bottomLeft + (-Vector2.right * gizmosRadius));
		Gizmos.DrawLine(raycastOrigins.bottomRight, raycastOrigins.bottomRight + (Vector2.right * gizmosRadius));
	}
}
