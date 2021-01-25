using System;
using UnityEngine;

namespace FrontierComponents
{
    public class UnitMover : MonoBehaviour
    {
        Rigidbody2D rb;
        GameObject unitInstance;

        public void InitComponent(GameObject unitInstance)
        {
            this.unitInstance = unitInstance;
            rb = unitInstance.GetComponent<Rigidbody2D>();
        }

        public void MoveToPosition(GameObject gameObject, Vector3 destinationPoint, float moveSpeed, Action onDestinationReached)
        {
            var goPos = gameObject.transform.position;
            var goRight = destinationPoint.x > goPos.x;
            rb.velocity = new Vector2(goRight ? moveSpeed : -moveSpeed, rb.velocity.y);
        }
    }
}