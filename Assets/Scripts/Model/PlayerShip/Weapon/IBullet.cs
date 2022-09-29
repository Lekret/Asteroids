using UnityEngine;

namespace Model.PlayerShip.Weapon
{
    public interface IBullet : IPositionable, IDestroyable, IHazardCollider
    {
        Quaternion Rotation { get; }
        void Update(float deltaTime);
        void FixedUpdate(float deltaTime);
    }
}