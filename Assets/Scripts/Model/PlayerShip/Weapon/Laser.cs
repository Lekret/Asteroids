using System;
using Model.Hazards;
using UnityEngine;

namespace Model.PlayerShip.Weapon
{
    public class Laser : ILaser
    {
        private readonly Lifetime _lifetime;

        public Laser(Vector2 position, Quaternion rotation, float lifetime)
        {
            Position = position;
            Rotation = rotation;
            _lifetime = new Lifetime(lifetime);
        }

        public Quaternion Rotation { get; }
        public Vector2 Position { get; }
        public event Action Destroyed
        {
            add => _lifetime.Destroyed += value;
            remove => _lifetime.Destroyed -= value;
        }
        
        public void Update(float deltaTime)
        {
            _lifetime.Update(deltaTime);
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