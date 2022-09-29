using System;
using Model.PlayerShip;
using UnityEngine;

namespace Model.Hazards
{
    public class Asteroid : IAsteroid
    {
        private readonly Vector2 _direction;
        private readonly Lifetime _lifetime;
        private readonly float _speed;
        private Vector2 _position;

        public Asteroid(Vector2 position, Vector2 direction, float speed, float lifetime)
        {
            _position = position;
            _direction = direction;
            _speed = speed;
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
            _position += _direction * _speed * deltaTime;
            PositionChanged?.Invoke(_position);
            _lifetime.Update(deltaTime);
        }
    }
}