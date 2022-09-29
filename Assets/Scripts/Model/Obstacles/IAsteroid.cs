using System;
using UnityEngine;

namespace Model.Obstacles
{
    public interface IAsteroid
    {
        Vector2 Position { get; }
        event Action<Vector2> PositionChanged;
        void Update(float deltaTime);
    }
}