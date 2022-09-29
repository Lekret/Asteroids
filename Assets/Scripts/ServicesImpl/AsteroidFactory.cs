using Configuration;
using Model.GameMap;
using Model.Obstacles;
using Services;
using UnityEngine;

namespace ServicesImpl
{
    public class AsteroidFactory : IAsteroidFactory
    {
        private readonly IAsteroidConfiguration _configuration;
        private readonly IRandomizer _randomizer;
        private readonly IMap _map;

        public AsteroidFactory(IAsteroidConfiguration configuration, IRandomizer randomizer, IMap map)
        {
            _configuration = configuration;
            _randomizer = randomizer;
            _map = map;
        }

        public IAsteroid Create()
        {
            var view = Object.Instantiate(_configuration.AsteroidPrefab);
            var asteroid = new Asteroid(
                _map.RandomOuterPoint(), 
                _randomizer.RandomDirection(), 
                _configuration.AsteroidLifetime);
            view.Init(asteroid);
            return asteroid;
        }
    }
}