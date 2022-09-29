using Game.PlayerShip.Weapon;
using UnityEngine;
using View;

namespace Services.Weapon
{
    public class LaserFactory : ILaserFactory
    {
        private readonly LaserView _prefab;

        public LaserFactory(LaserView prefab)
        {
            _prefab = prefab;
        }

        public Laser Create()
        {
            var laserView = Object.Instantiate(_prefab);
            var laser = new Laser();
            laserView.Init(laser);
            return laser;
        }
    }
}