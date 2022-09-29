using UnityEngine;

namespace Services.Randomizer
{
    public class Randomizer : IRandomizer
    {
        public float Range(float min, float max)
        {
            return Random.Range(min, max);
        }
    }
}