using View;

namespace Configuration
{
    public interface IAsteroidConfiguration
    {
        float BigAsteroidSpeed { get; }
        float SmallAsteroidSpeed { get; }
        AsteroidView AsteroidPrefab { get; }
        float AsteroidLifetime { get; }
    }
}