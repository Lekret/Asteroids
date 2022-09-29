using Configuration;
using Game.PlayerShip;
using UnityEngine;

namespace Game.Factories
{
    public class ShipFactory : IShipFactory
    {
        private readonly ShipConfiguration _shipConfiguration;
        private readonly Bounds _mapBounds;

        public ShipFactory(ShipConfiguration shipConfiguration, Bounds mapBounds)
        {
            _shipConfiguration = shipConfiguration;
            _mapBounds = mapBounds;
        }

        public Ship Create()
        {
            var shipMovement = new ShipMovement(
                _shipConfiguration.Acceleration,
                _shipConfiguration.MaxSpeed,
                _shipConfiguration.InertiaDrop);
            var shipRotation = new ShipRotation(_shipConfiguration.RotationSpeed);
            var shipTeleport = new ShipTeleport(_mapBounds, shipMovement);
            var ship = new Ship(shipMovement, shipRotation, shipTeleport);
            return ship;
        }
    }
}