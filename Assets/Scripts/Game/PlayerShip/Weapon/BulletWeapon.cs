using Services.Weapon;

namespace Game.PlayerShip.Weapon
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
            var bullet = _bulletFactory.Create();
            
        }
    }
}