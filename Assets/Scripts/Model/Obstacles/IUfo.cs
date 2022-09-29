using System;
using UnityEngine;

namespace Model.Obstacles
{
    public interface IUfo
    {
        event Action<Vector2> PositionChanged;
        void Update(float deltaTime);
    }
}