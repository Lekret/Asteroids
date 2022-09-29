using UnityEngine;

namespace Model.PlayerShip.Weapon
{
    public interface ILaser : IPositionable, IDestroyable, IHazardCollider
    {
        Quaternion Rotation { get; }

    }
}