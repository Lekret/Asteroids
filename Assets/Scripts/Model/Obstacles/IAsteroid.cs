using System;
using UnityEngine;

namespace Model.Obstacles
{
    public interface IAsteroid
    {
        event Action<Vector2> PositionChanged;
        void Update(float deltaTime);
    }
}