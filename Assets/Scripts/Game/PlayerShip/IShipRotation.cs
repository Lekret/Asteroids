using System;

namespace Game.PlayerShip
{
    public interface IShipRotation
    {
        float Current { get; }
        event Action<float> RotationChanged;
        void SetRotationInput(float rotationInput);
    }
}