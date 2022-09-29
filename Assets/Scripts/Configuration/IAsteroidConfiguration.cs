using View;

namespace Configuration
{
    public interface IAsteroidConfiguration
    {
        float BigAsteroidSpeed { get; }
        float SmallAsteroidSpeed { get; }
        AsteroidView BigAsteroidPrefab { get; }
        AsteroidView SmallAsteroidPrefab { get; }
        float AsteroidLifetime { get; }
    }
}