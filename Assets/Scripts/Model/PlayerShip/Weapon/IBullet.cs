using UnityEngine;

namespace Model.PlayerShip.Weapon
{
    public interface IBullet : IPositionable, IDestroyable, IHazardCollider
    {
        Quaternion Rotation { get; }
    }
}