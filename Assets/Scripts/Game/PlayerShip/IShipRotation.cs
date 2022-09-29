using System;

namespace Game.PlayerShip
{
    public interface IShipRotation
    {
        float Current { get; }
        event Action<float> Changed;
        void SetRotationInput(float rotationInput);
    }
}