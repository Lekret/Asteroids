using Configuration;
using Model.PlayerShip;
using Model.PlayerShip.Weapon;
using UnityEngine;

namespace Factories.Impl
{
    public class BulletFactory : IBulletFactory
    {
        private readonly ShipConfiguration _shipConfiguration;
        private readonly IShip _ship;

        public BulletFactory(ShipConfiguration shipConfiguration, IShip ship)
        {
            _shipConfiguration = shipConfiguration;
            _ship = ship;
        }

        public IBullet Create()
        {
            var view = Object.Instantiate(_shipConfiguration.BulletPrefab);
            var position = _ship.Movement.Position;
            var bullet = new Bullet(
                position, 
                _ship.Rotation.Current, 
                _shipConfiguration.BulletSpeed, 
                _shipConfiguration.BulletLifetime);
            view.Init(bullet);
            return bullet;
        }
    }
}