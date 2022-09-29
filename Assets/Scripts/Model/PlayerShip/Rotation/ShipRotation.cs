using System;
using UnityEngine;

namespace Model.PlayerShip.Rotation
{
    public class ShipRotation : IShipRotation
    {
        private readonly float _rotationSpeed;
        private float _eulerZ;
        private Quaternion _current;
        private float _rotationInput;

        public ShipRotation(float rotationSpeed)
        {
            _rotationSpeed = rotationSpeed;
        }

        public Quaternion Current => _current;
        public event Action<Quaternion> Changed;

        public void Update(float deltaTime)
        {
            _eulerZ += _rotationInput * _rotationSpeed * deltaTime;
            _current = Quaternion.AngleAxis(_eulerZ, Vector3.forward);
            Changed?.Invoke(_current);
        }

        public void SetRotationInput(float rotationInput)
        {
            _rotationInput = rotationInput;
        }
    }
}