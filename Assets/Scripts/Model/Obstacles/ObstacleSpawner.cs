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
            var rnd = _randomizer.Range(0f, 1f);
            if (rnd < 0.5f)
            {
                _asteroidFactory.Create();
            }
            else
            {
                _ufoFactory.Create();
            }
        }
    }
}