using UnityEngine;

namespace Units
{
    public class UnitMover : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private float moveSpeed;

        public Vector2 moveVector;
        
        private void FixedUpdate()
        {
            rb.velocity = moveVector;
        }

        public void GoRight()
        {
            moveVector = Vector2.right * moveSpeed * Time.deltaTime;
        }

        public void GoLeft()
        {
            moveVector = Vector2.left * moveSpeed * Time.deltaTime;
        }

        public void Stop()
        {
            moveVector = Vector2.zero;
        }
    }
}