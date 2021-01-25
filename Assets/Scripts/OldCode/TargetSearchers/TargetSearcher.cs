using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.TargetSearchers
{
	public abstract class TargetSearcher : MonoBehaviour, INPCInfoReader
	{
		[SerializeField] [ReadOnly] private NPCInfoHolder NPCInfoHolder;
		[SerializeField] private bool showSearchRadius;
		[SerializeField] private float updateTime = 0.5f;
		[SerializeField] private LayerMask searchingLayers;
		[ShowInInspector] [ReadOnly] GameObject closestTarget;
		[SerializeField] private GameObjectUnityEvent onClosestTargetUpdate;

		protected virtual float SearchRadius { get => NPCInfoHolder.NPCInfo.AttackSettings.EnemyNoticeDistance; }


		protected void Start()
		{
			StartCoroutine(SearchingRoutine());
		}

		private IEnumerator SearchingRoutine()
		{
			while (true)
			{
				closestTarget = GetClosestTarget();
				onClosestTargetUpdate.Invoke(closestTarget);
				yield return new WaitForSeconds(updateTime);
			}
		}

		private GameObject GetClosestTarget()
		{
			var pt = Physics2D.OverlapCircleAll(transform.position, SearchRadius, searchingLayers);
			if (pt.Length > 0)
			{
				return GetClosestOfTargets(pt, transform);
			}
			return null;
		}

		private GameObject GetClosestOfTargets(Collider2D[] targets, Transform fromThis)
		{
			GameObject bestTarget = null;
			float closestDistanceSqr = Mathf.Infinity;
			Vector3 currentPosition = fromThis.position;
			foreach (var potentialTarget in targets)
			{
				if (!ShouldInclude(potentialTarget.gameObject)) continue;

				Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
				float dSqrToTarget = directionToTarget.sqrMagnitude;
				if (dSqrToTarget < closestDistanceSqr)
				{
					closestDistanceSqr = dSqrToTarget;
					bestTarget = potentialTarget.gameObject;
				}
			}
			return bestTarget;
		}

		protected abstract bool ShouldInclude(GameObject gameObject);

		private void OnDrawGizmosSelected()
		{
			if (!showSearchRadius) return;
			Gizmos.DrawWireSphere(transform.position, SearchRadius);
		}

		public void SetNPCInfoHandler(NPCInfoHolder NPCInfoHolder)
		{
			this.NPCInfoHolder = NPCInfoHolder;
		}
	}
}