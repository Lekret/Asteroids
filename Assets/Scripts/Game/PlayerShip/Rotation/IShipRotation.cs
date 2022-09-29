using System;

namespace Game.PlayerShip.Rotation
{
    public interface IShipRotation
    {
        float Current { get; }
        event Action<float> Changed;
        void SetRotationInput(float rotationInput);
        void Update(float deltaTime);
    }
}