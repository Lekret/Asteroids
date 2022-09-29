using System;
using UnityEngine;

namespace Game.Ship
{
    public class ShipMovement
    {
        private readonly float _acceleration;
        private readonly float _maxSpeed;
        private Vector2 _velocity;
        private Vector2 _position;
        private float _forwardInput;

        public ShipMovement(float acceleration, float maxSpeed)
        {
            _acceleration = acceleration;
            _maxSpeed = maxSpeed;
        }

        public event Action<Vector2> PositionChanged;

        public void Update(float currentRotation, float deltaTime)
        {
            var rotation = Quaternion.AngleAxis(currentRotation, Vector3.forward);
            var velocityStep = rotation * new Vector2(0, _forwardInput * _acceleration);
            _velocity += (Vector2) velocityStep;
            _velocity = Vector2.ClampMagnitude(_velocity, _maxSpeed);
            _velocity = Vector2.Lerp(_velocity, Vector2.zero, deltaTime * _acceleration);
            _position += _velocity * deltaTime;
            PositionChanged?.Invoke(_position);
        }
        
        public void SetForwardInput(float forwardInput)
        {
            _forwardInput = forwardInput;
        }
    }
}