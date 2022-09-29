using Factories;

namespace Model.PlayerShip.Weapon
{
    public class BulletWeapon : IShipWeapon
    {
        private readonly IBulletFactory _bulletFactory;

        public BulletWeapon(IBulletFactory bulletFactory)
        {
            _bulletFactory = bulletFactory;
        }

        public void Use()
        {
            _bulletFactory.Create();
        }
    }
}