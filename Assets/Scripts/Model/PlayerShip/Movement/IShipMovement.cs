using System;
using UnityEngine;

namespace Model.PlayerShip.Movement
{
    public interface IShipMovement : IPositionable
    {
        event Action<Vector2> VelocityChanged;
        new Vector2 Position { get; set; }
        void SetForwardInput(float forwardInput);
        void FixedUpdate(Quaternion rotation, float deltaTime);
    }
}