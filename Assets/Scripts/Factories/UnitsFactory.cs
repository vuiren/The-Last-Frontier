using System;
using Base;
using Controllers;
using QFSW.QC;
using Services;
using Units;
using UnityEngine;
using Zenject;

namespace Factories
{
    public class UnitsFactory : MonoBehaviour
    {
        [SerializeField] private GameObject soldierPrefab;

        [Inject]
        public void Construct(IActorsService actorsService)
        {
            
        }

        [Command("unitsFactory.createSoldier")]
        public void CreateSoldier(Vector2 position)
        {
            var soldierInstance = Instantiate(soldierPrefab, position, new Quaternion());
            var actor = soldierInstance.GetComponentInChildren<Actor>();
            actor.id = -1;

            var unit = soldierInstance.GetComponentInChildren<Unit>();
        //    _unitsController.RegisterUnit(unit);
        }
    } 
}