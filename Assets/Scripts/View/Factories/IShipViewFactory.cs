using Game.Ship;

namespace View.Factories
{
    public interface IShipViewFactory
    {
        ShipView Create(ShipMovement shipMovement, ShipRotation shipRotation);
    }
}