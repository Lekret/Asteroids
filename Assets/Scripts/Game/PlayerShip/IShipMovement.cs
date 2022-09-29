using System;
using UnityEngine;

namespace Game.PlayerShip
{
    public interface IShipMovement
    {
        event Action<Vector2> PositionChanged;
        Vector2 Position { get; set; }
        void SetForwardInput(float forwardInput);
    }
}