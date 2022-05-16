using System;
using UnityEngine;

namespace Assets.Scripts.Attack
{
    public abstract class AttackController : MonoBehaviour, INPCInfoReader
	{
		[SerializeField] protected NPCInfoHolder NPCInfoHolder;

		[SerializeField] AudioSource audioSource;
		protected Action onAttack;

		float remainingTimeBeforeAttack;

		NPCInfo NPCInfo;

		private void Awake()
		{
			AddComponents();
			SubscribeToEvents();
		}

		protected virtual void AddComponents()
        {

        }

		protected virtual void SubscribeToEvents()
        {

        }

		protected void Update()
		{
			ReloadProcess();
			var target = NPCInfoHolder.AttackTarget;
			if (!target) return;

			if (ReadyToAttack(target))
				Attack();
		}

		private bool TargetInAttackingRange(GameObject target)
		{
			var boundsComponent = target.GetComponent<Collider2D>();
			if (!boundsComponent) return true;
			var bounds = target.GetComponent<Collider2D>().bounds;
			var leftestPoint = bounds.center - bounds.extents;
			var rightestPoint = bounds.center + bounds.extents;
			var midPoint = target.transform.position;

			var attackStartDistance = NPCInfo.AttackSettings.AttackStartDistance;
			var leftReached = DistanceTracker.IsObjectReachedDestination(transform.position, leftestPoint, attackStartDistance);
			var rightReached = DistanceTracker.IsObjectReachedDestination(transform.position, rightestPoint, attackStartDistance);
			var centerReached = DistanceTracker.IsObjectReachedDestination(transform.position, midPoint, attackStartDistance);
			return leftReached || rightReached || centerReached;
		}

		private void Attack()
		{
			remainingTimeBeforeAttack = NPCInfo.TimeBetweenAttacks;// timeBetweenAttacks;
			audioSource.PlayOneShot(NPCInfo.AttackSound);
			onAttack.Invoke();
		}

		private bool ReadyToAttack(GameObject target)
		{
			var timeCheck = remainingTimeBeforeAttack <= 0;
			var disanceCheck = TargetInAttackingRange(target);
			return timeCheck && disanceCheck;
		}

		void ReloadProcess()
		{
			remainingTimeBeforeAttack -= Time.deltaTime;
		}

		public void SetNPCInfoHandler(NPCInfoHolder NPCInfoHolder)
		{
			this.NPCInfoHolder = NPCInfoHolder;
			NPCInfo = NPCInfoHolder.NPCInfo;
		}
	}

}
