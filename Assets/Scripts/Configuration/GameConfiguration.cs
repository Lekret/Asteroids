using UnityEngine;
using View;

namespace Configuration
{
    [CreateAssetMenu(menuName = "Config/Game configuration", fileName = "GameConfiguration")]
    public class GameConfiguration : ScriptableObject,
        ISpawnConfiguration, IAsteroidConfiguration, IUfoConfiguration
    {
        [SerializeField] private AnimationCurve _timeUntilSpawnCurve;
        [SerializeField] private float _ufoSpeed;
        [SerializeField] private float _bigAsteroidSpeed;
        [SerializeField] private float _smallAsteroidSpeed;
        [SerializeField] private float _asteroidLifetime;
        [SerializeField] private AsteroidView _asteroidPrefab;
        [SerializeField] private UfoView _ufoPrefab;

        public AnimationCurve TimeUntilSpawnCurve => _timeUntilSpawnCurve;
        public float UfoSpeed => _ufoSpeed;
        public float BigAsteroidSpeed => _bigAsteroidSpeed;
        public float SmallAsteroidSpeed => _smallAsteroidSpeed;
        public float AsteroidLifetime => _asteroidLifetime;
        public AsteroidView AsteroidPrefab => _asteroidPrefab;
        public UfoView UfoPrefab => _ufoPrefab;
    }
}