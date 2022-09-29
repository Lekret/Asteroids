using System;
using Factories;
using UnityEngine;

namespace Model.PlayerShip.Weapon
{
    public class LaserWeapon : ILaserWeapon
    {
        private readonly ILaserFactory _laserFactory;
        private readonly int _maxAmmo;
        private int _ammo;

        public LaserWeapon(ILaserFactory laserFactory, int maxAmmo)
        {
            _laserFactory = laserFactory;
            _maxAmmo = maxAmmo;
            _ammo = maxAmmo;
        }

        public event Action AmmoChanged;
        public int MaxAmmo => _maxAmmo;
        public int Ammo => _ammo;

        public void AddAmmo()
        {
            _ammo = Mathf.Min(_ammo + 1, _maxAmmo);
            AmmoChanged?.Invoke();
        }

        public void Use()
        {
            if (_ammo <= 0)
                return;
            _laserFactory.Create();
            _ammo--;
            AmmoChanged?.Invoke();
        }
    }
}