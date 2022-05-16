using System;
using UnityEngine;

namespace Base
{
    public class Actor : MonoBehaviour
    {
        public int id;

        private void Awake()
        {
            IDTracker.LastID++;
        }
    }
}