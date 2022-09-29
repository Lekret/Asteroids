﻿using Configuration;
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
        private readonly Bounds _mapBounds;

        public ShipFactory(ShipConfiguration configuration, Bounds mapBounds)
        {
            _configuration = configuration;
            _mapBounds = mapBounds;
        }

        public IShip Create()
        {
            var shipMovement = new ShipMovement(
                _configuration.Acceleration,
                _configuration.MaxSpeed,
                _configuration.InertiaDrop);
            var shipRotation = new ShipRotation(_configuration.RotationSpeed);
            var shipTeleport = new ShipTeleport(_mapBounds, shipMovement);
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
            view.Init(shipMovement, shipRotation);
            return ship;
        }
    }
}