using Model.PlayerShip.Movement;
using Model.PlayerShip.Rotation;
using View;

namespace Services.PlayerShit
{
    public interface IShipViewFactory
    {
        ShipView Create(IShipMovement shipMovement, IShipRotation shipRotation);
    }
}