using System;
using UnityEngine;

namespace Game.PlayerShip
{
    public interface IShipMovement
    {
        event Action<Vector2> PositionChanged;
        void SetForwardInput(float forwardInput);
    }
}