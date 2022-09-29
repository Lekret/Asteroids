using System;
using Model.PlayerShip.Movement;
using UnityEngine;

namespace Model.Hazards
{
    public class Ufo : IUfo
    {
        private readonly IShipMovement _shipMovement;
        private readonly float _speed;
        private Vector2 _position;

        public Ufo(IShipMovement shipMovement, Vector3 position, float speed)
        {
            _shipMovement = shipMovement;
            _position = position;
            _speed = speed;
        }

        public Vector2 Position => _position;
        public event Action<Vector2> PositionChanged;
        public event Action Destroyed;

        public void FixedUpdate(float deltaTime)
        {
            _position = Vector2.MoveTowards(_position, _shipMovement.Position, _speed * deltaTime);
            PositionChanged?.Invoke(_position);
        }

        public void Destroy()
        {
            Destroyed?.Invoke();
        }
    }
}