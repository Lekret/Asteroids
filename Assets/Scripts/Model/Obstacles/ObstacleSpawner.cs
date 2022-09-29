using Services;
using UnityEngine;

namespace Model.Obstacles
{
    public class ObstacleSpawner : IObstacleSpawner
    {
        private readonly IAsteroidFactory _asteroidFactory;
        private readonly IUfoFactory _ufoFactory;
        private readonly IRandomizer _randomizer;
        private readonly AnimationCurve _timeUntilSpawnCurve;
        private float _gameTime;
        private float _timeUntilSpawn;
        
        public ObstacleSpawner(
            IAsteroidFactory asteroidFactory, 
            IUfoFactory ufoFactory,
            IRandomizer randomizer,
            AnimationCurve timeUntilSpawnCurve)
        {
            _asteroidFactory = asteroidFactory;
            _ufoFactory = ufoFactory;
            _randomizer = randomizer;
            _timeUntilSpawnCurve = timeUntilSpawnCurve;
        }

        public void Update(float deltaTime)
        {
            _gameTime += deltaTime;
            _timeUntilSpawn -= deltaTime;
            if (_timeUntilSpawn <= 0)
            {
                _timeUntilSpawn = _timeUntilSpawnCurve.Evaluate(_gameTime);
                SpawnObstacle();
            }
        }

        private void SpawnObstacle()
        {
            if (_randomizer.Boolean())
            {
                _asteroidFactory.Create(AsteroidSize.Big);
            }
            else
            {
                _ufoFactory.Create();
            }
        }
    }
}