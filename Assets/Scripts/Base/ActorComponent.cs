using System;
using UnityEngine;

namespace Base
{
    public abstract class ActorComponent : MonoBehaviour
    {
        protected Actor _actor;
        
        protected virtual void Awake()
        {
            _actor = GetComponentInParent<Actor>();
        }
    }
}