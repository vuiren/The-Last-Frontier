using Base;
using UnityEngine;

namespace Units
{
    public class UnitAttackController : AttackController
    {
        public override void Attack()
        {
            base.Attack();
            Debug.Log($"Unit {gameObject.name} attacking");
        }

        protected override void Update()
        {
            base.Update();
            if (attacking && readyToShoot)
            {
                Attack();
            }
        }
    }
}