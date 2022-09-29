using Configuration;
using Model.GameMap;
using Model.Hazards;
using Model.Hazards.Shatter;
using Services.Randomizer;
using UnityEngine;

namespace Factories.Impl
{
    public class AsteroidFactory : IAsteroidFactory
    {
        private readonly IAsteroidConfiguration _configuration;
        private readonly BigAsteroidShatter _bigAsteroidShatter;
        private readonly SmallAsteroidShatter _smallAsteroidShatter;
        private readonly IRandomizer _randomizer;
        private readonly IMap _map;

        public AsteroidFactory(
            IAsteroidConfiguration configuration,
            IMap map, 
            IRandomizer randomizer)
        {
            _configuration = configuration;
            _map = map;
            _randomizer = randomizer;
            _bigAsteroidShatter = new BigAsteroidShatter(this);
            _smallAsteroidShatter = new SmallAsteroidShatter();
        }

        public IAsteroid CreateBig()
        {
            var view = Object.Instantiate(_configuration.BigAsteroidPrefab);
            var position = _map.RandomOuterPoint();
            var direction = (_map.RandomInnerPoint() - position).normalized;
            var asteroid = new Asteroid(
                _bigAsteroidShatter,
                position, 
                direction, 
                _configuration.BigAsteroidSpeed,
                _configuration.AsteroidLifetime);
            view.Init(asteroid);
            return asteroid;
        }

        public IAsteroid CreateSmall(Vector3 position)
        {
            var view = Object.Instantiate(_configuration.SmallAsteroidPrefab);
            var asteroid = new Asteroid(
                _smallAsteroidShatter,
                position, 
                _randomizer.Direction(), 
                _configuration.SmallAsteroidSpeed,
                _configuration.AsteroidLifetime);
            view.Init(asteroid);
            return asteroid;
        }
    }
}