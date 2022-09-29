using Game.PlayerShip.Movement;
using Game.PlayerShip.Rotation;
using View;

namespace Services.PlayerShit
{
    public interface IShipViewFactory
    {
        ShipView Create(IShipMovement shipMovement, IShipRotation shipRotation);
    }
}