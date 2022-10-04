using System;
using Model.PlayerShip.Movement;
using Model.PlayerShip.Rotation;
using Model.PlayerShip.Weapon;

namespace Model.PlayerShip
{
    public interface IShip : IHazardCollider
    {
        IShipMovement Movement { get; }
        IShipRotation Rotation { get; }
        IShipWeapon PrimaryWeapon { get; }
        ILaserWeapon SecondaryWeapon { get; }
        ILaserCooldown LaserCooldown { get; }
        event Action Killed;
    }
}