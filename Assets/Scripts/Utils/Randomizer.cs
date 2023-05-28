using UnityEngine;

namespace Utils
{
    public static class Randomizer
    {
        public static T GetElement<T>(T[] array)
        {
            return array[Random.Range(0, array.Length)];
        }

        public static float GetValueFromVector(Vector2 minMax)
        {
            return Random.Range(minMax.x, minMax.y);
        }

        public static int GetValueFromVector(Vector2Int minMax)
        {
            return Random.Range(minMax.x, minMax.y);
        }
    }
}
