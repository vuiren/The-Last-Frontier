using UnityEngine;

namespace Extensions
{
    public static class VectorExtensions
    {
        public static Vector3 Vector3(this Vector2 vector)
        {
            return new Vector3(vector.x, vector.y);
        }
    }
}