using UnityEngine;

namespace Base
{
    [RequireComponent(typeof(Actor))]
    public class Building : MonoBehaviour
    {
        [SerializeField] private Actor actor;
        private void Awake()
        {
            actor = GetComponent<Actor>();
        }
    }
}