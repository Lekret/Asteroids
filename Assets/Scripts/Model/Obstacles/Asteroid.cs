using System;
using Model.PlayerShip;
using UnityEngine;

namespace Model.Obstacles
{
    public class Asteroid : IAsteroid
    {
        private readonly Vector2 _direction;
        private readonly Lifetime _lifetime;
        private Vector2 _position;

        public Asteroid(Vector2 position, Vector2 direction, float lifetime)
        {
            _direction = direction;
            _position = position;
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
            _position += _direction * deltaTime;
            PositionChanged?.Invoke(_position);
            _lifetime.Update(deltaTime);
        }
    }
}