using Model.PlayerShip.Weapon;

namespace Services.Weapon
{
    public interface ILaserFactory
    {
        Laser Create();
    }
}