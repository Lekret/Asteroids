using Model.PlayerShip.Weapon;

namespace Services.Weapon
{
    public interface IBulletFactory
    {
        Bullet Create();
    }
}