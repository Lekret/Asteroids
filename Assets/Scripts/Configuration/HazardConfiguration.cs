using UnityEngine;
using View;

namespace Configuration
{
    [CreateAssetMenu(menuName = "Config/Hazard configuration", fileName = "HazardConfiguration")]
    public class HazardConfiguration : ScriptableObject,
        ISpawnConfiguration, IAsteroidConfiguration, IUfoConfiguration
    {
        [SerializeField] private float _ufoSpeed;
        [SerializeField] private float _bigAsteroidSpeed;
        [SerializeField] private float _smallAsteroidSpeed;
        [SerializeField] private float _asteroidLifetime;
        [SerializeField] private AsteroidView _bigAsteroidPrefab;
        [SerializeField] private AsteroidView _smallAsteroidPrefab;
        [SerializeField] private UfoView _ufoPrefab;
        [SerializeField] private AnimationCurve _timeUntilSpawnCurve;

        public float UfoSpeed => _ufoSpeed;
        public float BigAsteroidSpeed => _bigAsteroidSpeed;
        public float SmallAsteroidSpeed => _smallAsteroidSpeed;
        public float AsteroidLifetime => _asteroidLifetime;
        public AsteroidView BigAsteroidPrefab => _bigAsteroidPrefab;
        public AsteroidView SmallAsteroidPrefab => _smallAsteroidPrefab;
        public UfoView UfoPrefab => _ufoPrefab;
        public AnimationCurve TimeUntilSpawnCurve => _timeUntilSpawnCurve;
    }
}