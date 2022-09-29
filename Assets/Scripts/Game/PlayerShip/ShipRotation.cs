using System;

namespace Game.PlayerShip
{
    public class ShipRotation : IShipRotation
    {
        private readonly float _rotationSpeed;
        private float _current;
        private float _rotationInput;

        public ShipRotation(float rotationSpeed)
        {
            _rotationSpeed = rotationSpeed;
        }

        public float Current => _current;
        public event Action<float> RotationChanged;

        public void Update(float deltaTime)
        {
            _current += _rotationInput * _rotationSpeed * deltaTime;
            RotationChanged?.Invoke(_current);
        }
        
        public void SetRotationInput(float rotationInput)
        {
            _rotationInput = rotationInput;
        }
    }
}