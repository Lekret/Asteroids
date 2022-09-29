using System;
using UnityEngine;

namespace Model.PlayerShip.Weapon
{
    public interface IBullet
    {
        Quaternion Rotation { get; }
        Vector2 Position { get; }
        event Action<Vector2> PositionChanged;
        void Update(float deltaTime);
    }
}