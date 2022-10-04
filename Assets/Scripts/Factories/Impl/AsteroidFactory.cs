using Configuration;
using Model.Execution;
using Model.GameMap;
using Model.Hazards;
using Model.Hazards.Shatter;
using Model.Score;
using Services.Randomizer;
using UnityEngine;

namespace Factories.Impl
{
    public class AsteroidFactory : IAsteroidFactory
    {
        private readonly IAsteroidConfiguration _configuration;
        private readonly BigAsteroidShatterer _bigAsteroidShatterer;
        private readonly SmallAsteroidShatterer _smallAsteroidShatterer;
        private readonly IRandomizer _randomizer;
        private readonly IScoreTracker _scoreTracker;
        private readonly IGameLoop _gameLoop;
        private readonly IMap _map;

        public AsteroidFactory(
            IAsteroidConfiguration configuration,
            IMap map,
            IRandomizer randomizer,
            IGameLoop gameLoop,
            IScoreTracker scoreTracker)
        {
            _configuration = configuration;
            _map = map;
            _randomizer = randomizer;
            _gameLoop = gameLoop;
            _scoreTracker = scoreTracker;
            _bigAsteroidShatterer = new BigAsteroidShatterer(this);
            _smallAsteroidShatterer = new SmallAsteroidShatterer();
        }

        public IAsteroid CreateBig()
        {
            var view = Object.Instantiate(_configuration.BigAsteroidPrefab);
            var position = _map.RandomOuterPoint();
            var direction = (_map.RandomInnerPoint() - position).normalized;
            var asteroid = new Asteroid(
                _bigAsteroidShatterer,
                position,
                direction,
                _configuration.BigAsteroidSpeed,
                _configuration.AsteroidLifetime);
            view.Init(asteroid);
            AddToGameLoop(asteroid);
            _scoreTracker.RegisterHazard(asteroid);
            return asteroid;
        }

        public IAsteroid CreateSmall(Vector3 position)
        {
            var view = Object.Instantiate(_configuration.SmallAsteroidPrefab);
            var asteroid = new Asteroid(
                _smallAsteroidShatterer,
                position,
                _randomizer.Direction(),
                _configuration.SmallAsteroidSpeed,
                _configuration.AsteroidLifetime);
            view.Init(asteroid);
            AddToGameLoop(asteroid);
            _scoreTracker.RegisterHazard(asteroid);
            return asteroid;
        }

        private void AddToGameLoop(Asteroid asteroid)
        {
            void OnAsteroidDestroyed()
            {
                _gameLoop.RemoveUpdate(asteroid);
                _gameLoop.RemoveFixedUpdate(asteroid);
                asteroid.Destroyed -= OnAsteroidDestroyed;
            }

            _gameLoop.AddUpdate(asteroid);
            _gameLoop.AddFixedUpdate(asteroid);
            asteroid.Destroyed += OnAsteroidDestroyed;
        }
    }
}