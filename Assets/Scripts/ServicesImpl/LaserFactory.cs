using Configuration;
using Model.PlayerShip;
using Model.PlayerShip.Weapon;
using Services;
using UnityEngine;

namespace ServicesImpl
{
    public class LaserFactory : ILaserFactory
    {
        private readonly ShipConfiguration _shipConfiguration;
        private readonly IShip _ship;

        public LaserFactory(ShipConfiguration shipConfiguration, IShip ship)
        {
            _shipConfiguration = shipConfiguration;
            _ship = ship;
        }

        public ILaser Create()
        {
            var view = Object.Instantiate(_shipConfiguration.LaserPrefab);
            var laser = new Laser(
                _ship.Movement.Position,
                _ship.Rotation.Current, 
                _shipConfiguration.LaserLifetime);
            view.Init(laser);
            return null;
        }
    }
}