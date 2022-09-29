using System;
using UnityEngine;

namespace Model
{
    public interface IPositionable
    {
        Vector2 Position { get; }
        event Action<Vector2> PositionChanged;
    }
}