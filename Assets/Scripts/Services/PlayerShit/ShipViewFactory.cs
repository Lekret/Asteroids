using Model.PlayerShip.Movement;
using Model.PlayerShip.Rotation;
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
            var view = Object.Instantiate(_prefab);
            view.Init(shipMovement, shipRotation);
            return view;
        }
    }
}