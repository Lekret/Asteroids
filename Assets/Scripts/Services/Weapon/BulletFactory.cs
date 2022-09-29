using Game.PlayerShip.Weapon;
using UnityEngine;
using View;

namespace Services.Weapon
{
    public class BulletFactory : IBulletFactory
    {
        private readonly BulletView _prefab;

        public BulletFactory(BulletView prefab)
        {
            _prefab = prefab;
        }

        public Bullet Create()
        {
            var bulletView = Object.Instantiate(_prefab);
            var bullet = new Bullet();
            bulletView.Init(bullet);
            return bullet;
        }
    }
}