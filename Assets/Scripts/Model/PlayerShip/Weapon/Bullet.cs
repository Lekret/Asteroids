using System;
using UnityEngine;

namespace Model.PlayerShip.Weapon
{
    public class Bullet : IBullet
    {
        private readonly Vector2 _direction;
        private readonly Quaternion _rotation;
        private Vector2 _position;

        public Bullet(Vector2 position, Quaternion rotation)
        {
            _position = position;
            _rotation = rotation;
            _direction = rotation * Vector3.up;
        }

        public Quaternion Rotation => _rotation;
        public Vector2 Position => _position;
        public event Action<Vector2> PositionChanged;
        
        public void Update(float deltaTime)
        {
            _position += _direction * deltaTime;
            PositionChanged?.Invoke(_position);
        }
    }
}