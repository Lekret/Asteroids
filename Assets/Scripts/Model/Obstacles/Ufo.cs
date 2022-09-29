using System;
using Model.PlayerShip.Movement;
using UnityEngine;

namespace Model.Obstacles
{
    public class Ufo : IUfo
    {
        private readonly IShipMovement _shipMovement;
        private readonly float _speed;
        private Vector2 _position;

        public Ufo(IShipMovement shipMovement, float speed)
        {
            _shipMovement = shipMovement;
            _speed = speed;
        }

        public Vector2 Position => _position;
        public event Action<Vector2> PositionChanged;

        public void Update(float deltaTime)
        {
            _position = Vector2.MoveTowards(_position, _shipMovement.Position, _speed * deltaTime);
            PositionChanged?.Invoke(_position);
        }
    }
}