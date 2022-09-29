using Factories;
using Services.Randomizer;
using UnityEngine;

namespace Model.Hazards
{
    public class HazardSpawner : IHazardSpawner
    {
        private readonly IAsteroidFactory _asteroidFactory;
        private readonly IUfoFactory _ufoFactory;
        private readonly IRandomizer _randomizer;
        private readonly AnimationCurve _timeUntilSpawnCurve;
        private float _gameTime;
        private float _timeUntilSpawn;
        
        public HazardSpawner(
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
                SpawnHazard();
            }
        }

        private void SpawnHazard()
        {
            if (_randomizer.Boolean())
            {
                _asteroidFactory.CreateBig();
            }
            else
            {
                _ufoFactory.Create();
            }
        }
    }
}