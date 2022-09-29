namespace Services
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
    }
}