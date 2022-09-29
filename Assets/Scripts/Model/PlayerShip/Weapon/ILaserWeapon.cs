using System;

namespace Model.PlayerShip.Weapon
{
    public interface ILaserWeapon : IShipWeapon
    {
        event Action Shot;
        int Ammo { get; }
    }
}