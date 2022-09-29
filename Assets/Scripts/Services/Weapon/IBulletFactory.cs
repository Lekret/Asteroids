using Game.PlayerShip.Weapon;

namespace Services.Weapon
{
    public interface IBulletFactory
    {
        Bullet Create();
    }
}