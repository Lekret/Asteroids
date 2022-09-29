using System;

namespace Model.PlayerShip.Weapon
{
    public interface ILaserWeapon : IShipWeapon
    {
        event Action AmmoChanged;
        int MaxAmmo { get; }
        int Ammo { get; }
        void AddAmmo();
    }
}