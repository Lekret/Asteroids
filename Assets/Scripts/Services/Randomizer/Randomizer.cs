using UnityEngine;

namespace Services.Randomizer
{
    public class Randomizer : IRandomizer
    {
        public int Range(int min, int max)
        {
            return Random.Range(min, max);
        }

        public float Range(float min, float max)
        {
            return Random.Range(min, max);
        }
    }
}