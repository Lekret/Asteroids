using System;
using UnityEngine;

namespace Model.PlayerShip.Rotation
{
    public interface IShipRotation
    {
        Quaternion Current { get; }
        event Action<Quaternion> Changed;
        void SetRotationInput(float rotationInput);
    }
}