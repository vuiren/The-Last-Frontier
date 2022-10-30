using System.Collections.Generic;
using System.Linq;
using Base;
using QFSW.QC;
using Services;
using Units;
using UnityEngine;
using Zenject;

namespace Controllers
{
    public class UnitsController : MonoBehaviour
    {
        private IHealthService _healthService;
        
        [Inject]
        public void Construct(IHealthService healthService)
        {
            _healthService = healthService;
        }
        
        [Command("units.damage")]
        private void DamageUnit(int actorId, int damageCount)
        {
            var healthCount = _healthService.GetHealth(actorId);
            _healthService.ChangeHealth(actorId, healthCount - damageCount);
        }


    }
}