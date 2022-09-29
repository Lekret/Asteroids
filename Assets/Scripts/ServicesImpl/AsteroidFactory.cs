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
        private readonly IMap _map;

        public AsteroidFactory(IAsteroidConfiguration configuration, IMap map)
        {
            _configuration = configuration;
            _map = map;
        }

        public IAsteroid Create()
        {
            var view = Object.Instantiate(_configuration.AsteroidPrefab);
            var position = _map.RandomOuterPoint();
            var direction = (_map.RandomInnerPoint() - position).normalized;
            var asteroid = new Asteroid(
                position, 
                direction, 
                _configuration.BigAsteroidSpeed,
                _configuration.AsteroidLifetime);
            view.Init(asteroid);
            return asteroid;
        }
    }
}