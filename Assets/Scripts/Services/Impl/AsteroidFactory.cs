using Model.Asteroids;
using UnityEngine;
using View;

namespace Services.Impl
{
    public class AsteroidFactory : IAsteroidFactory
    {
        private readonly AsteroidView _prefab;

        public AsteroidFactory(AsteroidView prefab)
        {
            _prefab = prefab;
        }

        public Asteroid Create()
        {
            var view = Object.Instantiate(_prefab);
            var asteroid = new Asteroid();
            view.Init(asteroid);
            return asteroid;
        }
    }
}