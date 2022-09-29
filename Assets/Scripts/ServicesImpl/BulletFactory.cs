using Model.PlayerShip;
using Model.PlayerShip.Weapon;
using Services;
using UnityEngine;
using View;

namespace ServicesImpl
{
    public class BulletFactory : IBulletFactory
    {
        private readonly BulletView _prefab;
        private readonly IShip _ship;
        private readonly float _bulletSpeed;

        public BulletFactory(BulletView prefab, float bulletSpeed, IShip ship)
        {
            _prefab = prefab;
            _bulletSpeed = bulletSpeed;
            _ship = ship;
        }

        public IBullet Create()
        {
            var view = Object.Instantiate(_prefab);
            var position = _ship.Movement.Position;
            var bullet = new Bullet(position, _ship.Rotation.Current, _bulletSpeed);
            view.Init(bullet);
            return bullet;
        }
    }
}