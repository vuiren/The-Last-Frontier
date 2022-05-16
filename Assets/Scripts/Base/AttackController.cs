using System;
using UnityEngine;

namespace Base
{
    public abstract class AttackController : MonoBehaviour
    {
        [SerializeField] private float timeBetweenShots;

        private float _remainingTime;
        public bool readyToShoot;
        public bool attacking;

        protected  virtual void Update()
        {
            _remainingTime -= timeBetweenShots * Time.deltaTime;

            if (_remainingTime < 0)
            {
                _remainingTime = -1;
            }
            readyToShoot = _remainingTime <= 0;
        }

        public virtual void StartAttacking()
        {
            attacking = true;
        }

        public virtual void Attack()
        {
            _remainingTime = timeBetweenShots;
        }

        public virtual void StopAttacking()
        {
            attacking = false;
        }
    }
}