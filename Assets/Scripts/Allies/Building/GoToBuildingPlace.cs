using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace Building
{
	public class GoToBuildingPlace : BuildingComponent
	{
		[SerializeField]
		GameObject marker;

		[SerializeField]
		protected Rigidbody2D rb;

		[SerializeField]
		protected float moveSpeed = 0.2f;

		[SerializeField]
		protected float stopDistance = 0.2f;

		[ShowInInspector]
		[ReadOnly]
		protected DirectionsEnum movingDirection;

		GameObject markerInstance;
		protected Vector3 pos;

		internal override void SubscribeToEvents()
		{
			base.SubscribeToEvents();
			eventsProxy.OnBuildingPlaceSetting += StartMovingToPosition;
		}

		protected void Update()
		{
			if(Input.GetMouseButtonDown(1))
			{
				eventsProxy.EndBuilding?.Invoke();
				GlobalDataTransfer.OnCommandTypeChange?.Invoke(CommandsEnum.GoTo);
				return;
			}
			var reached = DistanceTracker.IsObjectReachedDestination(transform.position, pos, stopDistance);
			if (reached)
			{
				StopMoving();
				OnPlaceReaching();
				enabled = false;
			}
		}

		internal void OnPlaceReaching()
		{
			eventsProxy.OnReachingBuildingPlace?.Invoke();
		}

		protected void StartMovingToPosition(Vector3 pos)
		{
			if (markerInstance)
				Destroy(markerInstance);
			markerInstance= Instantiate(marker, pos, new Quaternion());
			this.pos = pos;
			ChooseMovingDirection(pos);
			rb.velocity = new Vector2(movingDirection == DirectionsEnum.East ? moveSpeed : -moveSpeed, 0);
		}

		protected void StopMoving()
		{
			Destroy(markerInstance);
			rb.velocity = new Vector2();
		}

		protected void ChooseMovingDirection(Vector3 targetPos)
		{
			var dif = transform.position.x - targetPos.x;
			movingDirection = dif < 0 ? DirectionsEnum.East : DirectionsEnum.West;
		}

		internal override void EnableComponent()
		{
			StartMovingToPosition(pos);
		}

		internal override void DisableComponent()
		{
			StopMoving();
		}
	}
}