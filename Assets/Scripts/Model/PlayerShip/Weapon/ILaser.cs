using UnityEngine;

namespace Model.PlayerShip.Weapon
{
    public interface ILaser : IDestroyable, IHazardCollider
    {
        Vector2 Position { get; }
        Quaternion Rotation { get; }
        void Update(float deltaTime);
    }
}