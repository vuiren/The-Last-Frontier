using System;
using Controllers;
using OldCode.TargetSearchers;
using UnityEngine;
using UnityEngine.Serialization;

namespace Units
{
    public class UnitTargetSearcher : MonoBehaviour
    {
        [SerializeField] private Unit unit;
        [SerializeField] private Transform searchStart;
        [SerializeField] private float searchRadius;
        [SerializeField] private LayerMask searchingLayers;
        [SerializeField] private TargetSearcher _targetSearcher;
        [SerializeField] private GameObject closestTarget;

        private void Start()
        {
            _targetSearcher = new TargetSearcher(searchRadius, searchingLayers);
        }

        private void Update()
        {
            var newTarget = _targetSearcher.GetClosestTarget(searchStart.position);

            if (!newTarget && !closestTarget)
            {
                return;
            }

            if (closestTarget && !newTarget)
            {
                closestTarget = null;
                RelaxUnit();
                return;
            }
            
            if (!closestTarget)
            {
                closestTarget = newTarget;
                AlertUnit();
                return;
            }
            
            if (closestTarget && !newTarget)
            {
                closestTarget = null;
                return;
            }

            if (newTarget.GetInstanceID() == closestTarget.GetInstanceID())
            {
                return;
            }

            closestTarget = newTarget;
        }

        private void RelaxUnit()
        {
            var unitsController = FindObjectOfType<UnitsController>();
            unitsController.RelaxUnit(unit.ID);
        }

        private void AlertUnit()
        {
           var unitsController = FindObjectOfType<UnitsController>();
           unitsController.AlertUnit(unit.ID);
        }

        private void OnDrawGizmosSelected()
        {
            if (!searchStart) return;
            Gizmos.DrawWireSphere(searchStart.position, searchRadius);
        }
    }
}