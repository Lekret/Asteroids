using Factories;
using Model.Execution;
using Model.Score;
using Services.Randomizer;
using UnityEngine;

namespace Model.Hazards
{
    public class HazardSpawner : IHazardSpawner, IUpdatable
    {
        private readonly IAsteroidFactory _asteroidFactory;
        private readonly IUfoFactory _ufoFactory;
        private readonly IRandomizer _randomizer;
        private readonly IScoreTracker _scoreTracker;
        private readonly AnimationCurve _timeUntilSpawnCurve;
        private float _gameTime;
        private float _timeUntilSpawn;

        public HazardSpawner(
            IAsteroidFactory asteroidFactory,
            IUfoFactory ufoFactory,
            IRandomizer randomizer,
            IScoreTracker scoreTracker,
            AnimationCurve timeUntilSpawnCurve)
        {
            _asteroidFactory = asteroidFactory;
            _ufoFactory = ufoFactory;
            _randomizer = randomizer;
            _timeUntilSpawnCurve = timeUntilSpawnCurve;
            _scoreTracker = scoreTracker;
        }

        public void Update(float deltaTime)
        {
            _gameTime += deltaTime;
            _timeUntilSpawn -= deltaTime;
            if (_timeUntilSpawn <= 0)
            {
                _timeUntilSpawn = _timeUntilSpawnCurve.Evaluate(_gameTime);
                var hazard = SpawnHazard();
                _scoreTracker.RegisterHazard(hazard);
            }
        }

        private IDestroyable SpawnHazard()
        {
            if (_randomizer.Boolean())
            {
                return _asteroidFactory.CreateBig();
            }

            return _ufoFactory.Create();
        }
    }
}