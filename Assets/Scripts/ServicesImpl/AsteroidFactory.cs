using System;
using Configuration;
using Model.GameMap;
using Model.Obstacles;
using Services;
using View;
using Object = UnityEngine.Object;

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

        public IAsteroid Create(AsteroidSize size)
        {
            var view = Object.Instantiate(GetPrefab(size));
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

        private AsteroidView GetPrefab(AsteroidSize size)
        {
            switch (size)
            {
                case AsteroidSize.Big:
                    return _configuration.BigAsteroidPrefab;
                case AsteroidSize.Small:
                    return _configuration.SmallAsteroidPrefab;
                default:
                    throw new ArgumentOutOfRangeException(nameof(size), size, null);
            }
        }
    }
}