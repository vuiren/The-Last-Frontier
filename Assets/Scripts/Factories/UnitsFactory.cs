using System;
using Base;
using Controllers;
using QFSW.QC;
using Units;
using UnityEngine;

namespace Factories
{
    public class UnitsFactory : MonoBehaviour
    {
        [SerializeField] private GameObject soldierPrefab;
        private UnitsController _unitsController;
        private void Awake()
        {
            _unitsController = FindObjectOfType<UnitsController>();
        }

        [Command("unitsFactory.createSoldier")]
        public void CreateSoldier(Vector2 position)
        {
            var soldierInstance = Instantiate(soldierPrefab, position, new Quaternion());
            var actor = soldierInstance.GetComponentInChildren<Actor>();
            actor.id = IDTracker.LastID;

            var unit = soldierInstance.GetComponentInChildren<Unit>();
            _unitsController.RegisterUnit(unit);
        }
    } 
}