using Configuration;
using Game.Ship;

namespace Game.Factories
{
    public class ShipFactory : IShipFactory
    {
        private readonly ShipConfiguration _shipConfiguration;

        public ShipFactory(ShipConfiguration shipConfiguration)
        {
            _shipConfiguration = shipConfiguration;
        }

        public Ship.Ship Create()
        {
            var shipMovement = new ShipMovement(
                _shipConfiguration.Acceleration,
                _shipConfiguration.MaxSpeed,
                _shipConfiguration.InertiaDrop);
            var shipRotation = new ShipRotation(_shipConfiguration.RotationSpeed);
            var ship = new Ship.Ship(shipMovement, shipRotation);
            return ship;
        }
    }
}