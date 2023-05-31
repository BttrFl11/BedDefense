using UnityEngine;

namespace Utils
{
    public static class Geometry
    {
        public static float GetRotationByDirection(Vector2 direction)
        {
            float rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            return rotation;
        }
    }
}
