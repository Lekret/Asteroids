using System;
using UnityEngine;

namespace Model.Obstacles
{
    public class Asteroid : IAsteroid
    {
        private readonly Vector2 _direction;
        private Vector2 _position;

        public Asteroid(Vector2 direction, Vector2 position)
        {
            _direction = direction;
            _position = position;
        }

        public Vector2 Position => _position;
        public event Action<Vector2> PositionChanged;
        
        public void Update(float deltaTime)
        {
            _position += _direction * deltaTime;
            PositionChanged?.Invoke(_position);
        }
    }
}