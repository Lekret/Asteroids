using Model.GameMap;
using Model.PlayerShip.Movement;
using UnityEngine;

namespace Model.PlayerShip.Teleport
{
    public class ShipTeleport : IShipTeleport
    {
        private readonly IMap _map;
        private readonly IShipMovement _shipMovement;

        public ShipTeleport(IMap map, IShipMovement shipMovement)
        {
            _map = map;
            _shipMovement = shipMovement;
        }

        public void Update()
        {
            var mapBounds = _map.Bounds;
            var teleportPosition = GetTeleportPosition(_shipMovement.Position, mapBounds.min, mapBounds.max);
            if (teleportPosition.HasValue)
            {
                _shipMovement.Position = teleportPosition.Value;
            }
        }

        private static Vector2? GetTeleportPosition(Vector2 shipPosition, Vector2 min, Vector2 max)
        {
            for (var i = 0; i < 2; i++)
            {
                if (shipPosition[i] < min[i])
                {
                    shipPosition[i] = max[i];
                    return shipPosition;
                }

                if (shipPosition[i] > max[i])
                {
                    shipPosition[i] = min[i];
                    return shipPosition;
                }
            }

            return null;
        }
    }
}