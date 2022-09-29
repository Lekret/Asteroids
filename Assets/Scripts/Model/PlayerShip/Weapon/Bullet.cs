﻿using System;
using UnityEngine;

namespace Model.PlayerShip.Weapon
{
    public class Bullet : IBullet
    {
        private readonly Vector2 _direction;
        private readonly Quaternion _rotation;
        private readonly Lifetime _lifetime;
        private Vector2 _position;

        public Bullet(Vector2 position, Quaternion rotation, float speed, float lifetime)
        {
            _position = position;
            _rotation = rotation;
            _direction = rotation * Vector3.up * speed;
            _lifetime = new Lifetime(lifetime);
        }

        public Quaternion Rotation => _rotation;
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