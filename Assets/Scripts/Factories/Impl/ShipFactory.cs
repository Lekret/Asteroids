using Configuration;
using Model.GameMap;
using Model.PlayerShip;
using Model.PlayerShip.Movement;
using Model.PlayerShip.Rotation;
using Model.PlayerShip.Teleport;
using Model.PlayerShip.Weapon;
using UnityEngine;

namespace Factories.Impl
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
            var movement = new ShipMovement(
                _configuration.Acceleration,
                _configuration.MaxSpeed,
                _configuration.InertiaDrop);
            var ship = new Ship();
            var rotation = new ShipRotation(_configuration.RotationSpeed);
            var teleport = new ShipTeleport(_map, movement);
            var bulletFactory = new BulletFactory(_configuration, ship);
            var primaryWeapon = new BulletWeapon(bulletFactory);
            var laserFactory = new LaserFactory(_configuration, ship);
            var secondaryWeapon = new LaserWeapon(laserFactory, _configuration.LaserMaxAmmo);
            ship.Movement = movement;
            ship.Rotation = rotation;
            ship.Teleport = teleport;
            ship.LaserCooldown = new LaserCooldown(secondaryWeapon, _configuration.LaserCooldown);
            ship.PrimaryWeapon = primaryWeapon;
            ship.SecondaryWeapon = secondaryWeapon;
            var view = Object.Instantiate(_configuration.ShipPrefab);
            view.Init(ship);
            return ship;
        }
    }
}