using UnityEngine;

namespace Services.Randomizer
{
    public interface IRandomizer
    {
        int Range(int min, int max);
        float Range(float min, float max);
    }
    
    public static class RandomizerExtensions 
    {
        public static bool Boolean(this IRandomizer randomizer)
        {
            return randomizer.Range(0f, 1f) < 0.5f;
        }

        public static Vector2 Direction(this IRandomizer randomizer)
        {
            float Rnd() => randomizer.Range(-1f, 1f + float.Epsilon);
            return new Vector2(Rnd(), Rnd()).normalized;
        }
    }
}