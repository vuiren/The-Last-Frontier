using System;
using System.Collections.Generic;
using System.Linq;
using Extensions;
using UnityEngine;

namespace OldCode.TargetSearchers
{
    [Serializable]
    public class TargetSearcher
    {
        private readonly float _searchRadius;
        private readonly LayerMask _searchingLayers; 
        private readonly Collider2D[] _results;
        
        public TargetSearcher(float searchRadius, LayerMask searchingLayers)
        {
            _searchRadius = searchRadius;
            _searchingLayers = searchingLayers;
            _results = new Collider2D[10];
        }

        public GameObject GetClosestTarget(Vector2 startPoint)
        {
            var size =Physics2D.OverlapCircleNonAlloc(startPoint, _searchRadius, _results, _searchingLayers);
            return size > 0
                ? GetClosestOfTargets(_results, startPoint)
                : null;
        }

        private GameObject GetClosestOfTargets(IEnumerable<Collider2D> targets, Vector2 start)
        {
            GameObject bestTarget = null;
            var closestDistanceSqr = Mathf.Infinity;
            foreach (var potentialTarget in targets)
            {
                if(!potentialTarget) continue;
                //if (!ShouldInclude(potentialTarget.gameObject)) continue
                var directionToTarget = potentialTarget.transform.position - start.Vector3();
                var dSqrToTarget = directionToTarget.sqrMagnitude;
                if (!(dSqrToTarget < closestDistanceSqr)) continue;
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget.gameObject;
            }

            return bestTarget;
        }
    }
}