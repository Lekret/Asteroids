using Game.PlayerShip;

namespace View.Factories
{
    public interface IShipViewFactory
    {
        ShipView Create(IShipMovement shipMovement, IShipRotation shipRotation);
    }
}