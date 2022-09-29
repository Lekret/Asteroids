using Model.PlayerShip;

namespace Services
{
    public interface IShipFactory
    {
        IShip Create();
    }
}