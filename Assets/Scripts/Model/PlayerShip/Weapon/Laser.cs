using System;
using Model.Hazards;
using UnityEngine;

namespace Model.PlayerShip.Weapon
{
    public class Laser : ILaser
    {
        private readonly Quaternion _rotation;
        private readonly Lifetime _lifetime;
        private readonly Vector2 _position;

        public Laser(Vector2 position, Quaternion rotation, float lifetime)
        {
            _position = position;
            _rotation = rotation;
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

        public void CollideWith(IAsteroid asteroid)
        {
            asteroid.Destroy();
        }

        public void CollideWith(IUfo ufo)
        {
            ufo.Destroy();
        }
    }
}