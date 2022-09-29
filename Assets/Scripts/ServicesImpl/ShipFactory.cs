using Configuration;
using Model.GameMap;
using Model.PlayerShip;
using Model.PlayerShip.Movement;
using Model.PlayerShip.Rotation;
using Model.PlayerShip.Teleport;
using Model.PlayerShip.Weapon;
using Services;
using UnityEngine;

namespace ServicesImpl
{
    public class ShipFactory : IShipFactory
    {
        private readonly ShipConfiguration _configuration;
        private readonly IMap _map;

        public ShipFactory(ShipConfiguration configuration, IMap map)
        {
            _configuration = configuration;
            _map = map;
        }

        public IShip Create()
        {
            var shipMovement = new ShipMovement(
                _configuration.Acceleration,
                _configuration.MaxSpeed,
                _configuration.InertiaDrop);
            var shipRotation = new ShipRotation(_configuration.RotationSpeed);
            var shipTeleport = new ShipTeleport(_map, shipMovement);
            var bulletFactory = new BulletFactory(_configuration.BulletPrefab);
            var primaryWeapon = new BulletWeapon(bulletFactory);
            var laserFactory = new LaserFactory(_configuration.LaserPrefab);
            var secondaryWeapon = new LaserWeapon(laserFactory);
            var ship = new Ship(
                shipMovement,
                shipRotation,
                shipTeleport, 
                primaryWeapon,
                secondaryWeapon);
            var view = Object.Instantiate(_configuration.ShipPrefab);
            view.Init(ship);
            return ship;
        }
    }
}