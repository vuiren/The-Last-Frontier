using Base;
using UnityEngine;

namespace Units
{
    [RequireComponent(typeof(Actor))]
    public class Unit : MonoBehaviour
    {
        private Actor _actor;

        public int ID => _actor.id;

        private void Awake()
        {
            _actor = GetComponent<Actor>();
        }
    }
}