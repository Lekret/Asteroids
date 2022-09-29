using UnityEngine;

namespace Services
{
    public interface IRandomizer
    {
        int Range(int min, int max);
        float Range(float min, float max);
        Vector2 RandomDirection();
    }
}