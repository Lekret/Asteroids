using Model.PlayerShip.Movement;
using UnityEngine;

namespace Model.PlayerShip.Teleport
{
    public class ShipTeleport : IShipTeleport
    {
        private readonly Bounds _mapBounds;
        private readonly IShipMovement _shipMovement;

        public ShipTeleport(Bounds mapBounds, IShipMovement shipMovement)
        {
            _mapBounds = mapBounds;
            _shipMovement = shipMovement;
        }

        public void Update()
        {
            var teleportPosition = GetTeleportPosition(_shipMovement.Position, _mapBounds.min, _mapBounds.max);
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