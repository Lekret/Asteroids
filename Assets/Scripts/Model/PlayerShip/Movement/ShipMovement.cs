using System;
using UnityEngine;

namespace Model.PlayerShip.Movement
{
    public class ShipMovement : IShipMovement
    {
        private readonly float _acceleration;
        private readonly float _maxSpeed;
        private readonly float _inertiaDrop;
        private Vector2 _velocity;
        private Vector2 _position;
        private float _forwardInput;

        public ShipMovement(float acceleration, float maxSpeed, float inertiaDrop)
        {
            _acceleration = acceleration;
            _maxSpeed = maxSpeed;
            _inertiaDrop = inertiaDrop;
        }

        public event Action<Vector2> PositionChanged;
        public event Action<Vector2> VelocityChanged;

        public Vector2 Position
        {
            get => _position;
            set
            {
                _position = value;
                PositionChanged?.Invoke(_position);
            }
        }

        public void FixedUpdate(Quaternion rotation, float deltaTime)
        {
            var transformedInput = rotation * new Vector2(0, _forwardInput * _acceleration * deltaTime);
            _velocity += (Vector2) transformedInput;
            _velocity = Vector2.ClampMagnitude(_velocity, _maxSpeed);
            _position += _velocity * deltaTime;
            _velocity = Vector2.Lerp(_velocity, Vector2.zero, _inertiaDrop * deltaTime);
            PositionChanged?.Invoke(_position);
            VelocityChanged?.Invoke(_velocity);
        }

        public void SetForwardInput(float forwardInput)
        {
            _forwardInput = forwardInput;
        }
    }
}