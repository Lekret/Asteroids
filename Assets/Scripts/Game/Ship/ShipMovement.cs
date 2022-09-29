using System;
using UnityEngine;

namespace Game.Ship
{
    public class ShipMovement
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

        public void Update(float currentRotation, float deltaTime)
        {
            var rotation = Quaternion.AngleAxis(currentRotation, Vector3.forward);
            var frameStep = rotation * new Vector2(0, _forwardInput * _acceleration * deltaTime);
            _velocity += (Vector2) frameStep;
            _velocity = Vector2.ClampMagnitude(_velocity, _maxSpeed);
            _position += _velocity * deltaTime;
            _velocity = Vector2.Lerp(_velocity, Vector2.zero, _inertiaDrop * deltaTime);
            PositionChanged?.Invoke(_position);
        }
        
        public void SetForwardInput(float forwardInput)
        {
            _forwardInput = forwardInput;
        }
    }
}