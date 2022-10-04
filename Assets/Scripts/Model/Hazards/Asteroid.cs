using System;
using Model.Execution;
using Model.Hazards.Shatter;
using Model.PlayerShip;
using UnityEngine;

namespace Model.Hazards
{
    public class Asteroid : IAsteroid, IUpdatable, IFixedUpdatable
    {
        private readonly IAsteroidShatterer _asteroidShatterer;
        private readonly Vector2 _direction;
        private readonly Lifetime _lifetime;
        private Vector2 _position;

        public Asteroid(
            IAsteroidShatterer asteroidShatterer,
            Vector2 position,
            Vector2 direction,
            float speed,
            float lifetime)
        {
            _asteroidShatterer = asteroidShatterer;
            _position = position;
            _direction = direction * speed;
            _lifetime = new Lifetime(lifetime);
        }

        public Vector2 Position => _position;
        public event Action<Vector2> PositionChanged;

        public event Action Destroyed
        {
            add => _lifetime.Destroyed += value;
            remove => _lifetime.Destroyed -= value;
        }

        public void Update(float deltaTime)
        {
            _lifetime.Update(deltaTime);
        }

        public void FixedUpdate(float deltaTime)
        {
            _position += _direction * deltaTime;
            PositionChanged?.Invoke(_position);
        }

        public void Destroy()
        {
            _lifetime.End();
        }

        public void Shatter()
        {
            _asteroidShatterer.Shatter(this);
        }
    }
}