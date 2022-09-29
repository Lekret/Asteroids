using System;
using UnityEngine;

namespace Model.PlayerShip.Movement
{
    public interface IShipMovement
    {
        event Action<Vector2> PositionChanged;
        Vector2 Position { get; set; }
        void SetForwardInput(float forwardInput);
        void Update(float currentRotation, float deltaTime);
    }
}