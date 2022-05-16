using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace Assets.Scripts.TargetSearchers
{
	public abstract class TargetSearcherMono : MonoBehaviour, INPCInfoReader
	{
		[SerializeField] private NPCInfoHolder npcInfoHolder;
		[SerializeField] private bool showSearchRadius;
		[SerializeField] private float updateTime = 0.5f;
		[SerializeField] private LayerMask searchingLayers;
		private GameObject _closestTarget;
		[SerializeField] private GameObjectUnityEvent onClosestTargetUpdate;

		private float SearchRadius => npcInfoHolder.NPCInfo.AttackSettings.EnemyNoticeDistance;


		protected void Start()
		{
			StartCoroutine(SearchingRoutine());
		}

		private IEnumerator SearchingRoutine()
		{
			while (true)
			{
				_closestTarget = GetClosestTarget();
				onClosestTargetUpdate.Invoke(_closestTarget);
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
			var closestDistanceSqr = Mathf.Infinity;
			var currentPosition = fromThis.position;
			foreach (var potentialTarget in targets)
			{
				if (!ShouldInclude(potentialTarget.gameObject)) continue;

				var directionToTarget = potentialTarget.transform.position - currentPosition;
				var dSqrToTarget = directionToTarget.sqrMagnitude;
				if (!(dSqrToTarget < closestDistanceSqr)) continue;
				closestDistanceSqr = dSqrToTarget;
				bestTarget = potentialTarget.gameObject;
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
			this.npcInfoHolder = NPCInfoHolder;
		}
	}
}