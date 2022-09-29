using Game.PlayerShip.Movement;
using Game.PlayerShip.Rotation;
using UnityEngine;
using View;

namespace Services.PlayerShit
{
    public class ShipViewFactory : IShipViewFactory
    {
        private readonly ShipView _prefab;

        public ShipViewFactory(ShipView prefab)
        {
            _prefab = prefab;
        }

        public ShipView Create(IShipMovement shipMovement, IShipRotation shipRotation)
        {
            var shipView = Object.Instantiate(_prefab);
            shipView.Init(shipMovement, shipRotation);
            return shipView;
        }
    }
}