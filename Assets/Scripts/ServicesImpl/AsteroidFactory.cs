using Model.GameMap;
using Model.Obstacles;
using Services;
using UnityEngine;
using View;

namespace ServicesImpl
{
    public class AsteroidFactory : IAsteroidFactory
    {
        private readonly AsteroidView _prefab;
        private readonly IRandomizer _randomizer;
        private readonly IMap _map;

        public AsteroidFactory(AsteroidView prefab, IRandomizer randomizer, IMap map)
        {
            _prefab = prefab;
            _randomizer = randomizer;
            _map = map;
        }

        public IAsteroid Create()
        {
            var view = Object.Instantiate(_prefab);
            var asteroid = new Asteroid(_map.RandomOuterPoint(), _randomizer.RandomDirection());
            view.Init(asteroid);
            return asteroid;
        }
    }
}