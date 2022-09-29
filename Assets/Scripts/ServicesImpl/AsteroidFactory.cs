using Model.Obstacles;
using Services;
using UnityEngine;
using View;

namespace ServicesImpl
{
    public class AsteroidFactory : IAsteroidFactory
    {
        private readonly AsteroidView _prefab;

        public AsteroidFactory(AsteroidView prefab)
        {
            _prefab = prefab;
        }

        public IAsteroid Create()
        {
            var view = Object.Instantiate(_prefab);
            var asteroid = new Asteroid();
            view.Init(asteroid);
            return asteroid;
        }
    }
}