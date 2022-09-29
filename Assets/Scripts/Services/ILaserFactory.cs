using Model.PlayerShip.Weapon;

namespace Services
{
    public interface ILaserFactory
    {
        ILaser Create();
    }
}