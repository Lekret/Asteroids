using System;
using Services;

namespace Model.PlayerShip.Weapon
{
    public class LaserWeapon : IShipWeapon
    {
        private readonly ILaserFactory _laserFactory;
        private int _ammo;

        public LaserWeapon(ILaserFactory laserFactory)
        {
            _laserFactory = laserFactory;
        }

        public event Action Shot;
        public int Ammo => _ammo;
        
        public void AddAmmo()
        {
            _ammo++;
        }

        public void Use()
        {
            if (_ammo <= 0)
                return;
            _laserFactory.Create();
            _ammo--;
            Shot?.Invoke();
        }
    }
}