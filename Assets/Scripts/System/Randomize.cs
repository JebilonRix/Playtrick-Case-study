using UnityEngine;

namespace RedPanda
{
    public static class Randoming
    {
        public static float RandomFloat(float maxValue)
        {
            return Random.Range(0, maxValue);
        }
        public static int RandomInt(int maxValue)
        {
            return Random.Range(0, maxValue);
        }
        public static int RandomInt(int minValue, int maxValue)
        {
            return Random.Range(minValue, maxValue);
        }
    }
}