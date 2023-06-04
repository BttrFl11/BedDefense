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

        public static Vector2 GetRandomCircleSurfacePosition(Vector2 center, float radius)
        {
            Vector2 circle = new Vector2(Random.onUnitSphere.x, Random.onUnitSphere.y).normalized;
            return new Vector2(center.x + circle.x * radius, center.y + circle.y * radius);
        }
    }
}
