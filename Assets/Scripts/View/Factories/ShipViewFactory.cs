using Game.Ship;
using UnityEngine;

namespace View.Factories
{
    public class ShipViewFactory : IShipViewFactory
    {
        private readonly ShipView _prefab;

        public ShipViewFactory(ShipView prefab)
        {
            _prefab = prefab;
        }

        public ShipView Create(ShipMovement shipMovement, ShipRotation shipRotation)
        {
            var shipView = Object.Instantiate(_prefab);
            shipView.Init(shipMovement, shipRotation);
            return shipView;
        }
    }
}