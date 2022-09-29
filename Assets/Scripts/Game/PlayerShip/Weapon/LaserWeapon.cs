using Services.Weapon;

namespace Game.PlayerShip.Weapon
{
    public class LaserWeapon : IShipWeapon
    {
        private readonly ILaserFactory _laserFactory;

        public LaserWeapon(ILaserFactory laserFactory)
        {
            _laserFactory = laserFactory;
        }

        public void Use()
        {
            _laserFactory.Create();
        }
    }
}