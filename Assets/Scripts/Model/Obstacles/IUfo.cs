using System;
using UnityEngine;

namespace Model.Obstacles
{
    public interface IUfo
    {
        Vector2 Position { get; }
        event Action<Vector2> PositionChanged;
        void Update(float deltaTime);
    }
}