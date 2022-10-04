using Configuration;
using Model.Execution;
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
        private readonly IGameLoop _gameLoop;

        public ShipFactory(ShipConfiguration configuration, IMap map, IGameLoop gameLoop)
        {
            _configuration = configuration;
            _map = map;
            _gameLoop = gameLoop;
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
            var bulletFactory = new BulletFactory(_configuration, ship, _gameLoop);
            var primaryWeapon = new BulletWeapon(bulletFactory);
            var laserFactory = new LaserFactory(_configuration, ship, _gameLoop);
            var secondaryWeapon = new LaserWeapon(laserFactory, _configuration.LaserMaxAmmo);
            ship.Movement = movement;
            ship.Rotation = rotation;
            ship.Teleport = teleport;
            ship.LaserCooldown = new LaserCooldown(secondaryWeapon, _configuration.LaserCooldown);
            ship.PrimaryWeapon = primaryWeapon;
            ship.SecondaryWeapon = secondaryWeapon;
            var view = Object.Instantiate(_configuration.ShipPrefab);
            view.Init(ship);
            AddToGameLoop(ship);
            return ship;
        }

        private void AddToGameLoop(Ship ship)
        {
            void OnShipKilled()
            {
                _gameLoop.RemoveUpdate(ship);
                _gameLoop.RemoveFixedUpdate(ship);
                ship.Killed -= OnShipKilled;
            }
            
            _gameLoop.AddUpdate(ship);
            _gameLoop.AddFixedUpdate(ship);
            ship.Killed += OnShipKilled;
        }
    }
}