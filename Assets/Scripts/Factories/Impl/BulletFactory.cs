using Configuration;
using Model.Execution;
using Model.PlayerShip;
using Model.PlayerShip.Weapon;
using UnityEngine;

namespace Factories.Impl
{
    public class BulletFactory : IBulletFactory
    {
        private readonly ShipConfiguration _shipConfiguration;
        private readonly IShip _ship;
        private readonly IGameLoop _gameLoop;

        public BulletFactory(
            ShipConfiguration shipConfiguration,
            IShip ship,
            IGameLoop gameLoop)
        {
            _shipConfiguration = shipConfiguration;
            _ship = ship;
            _gameLoop = gameLoop;
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
            AddToGameLoop(bullet);
            return bullet;
        }

        private void AddToGameLoop(Bullet bullet)
        {
            void OnBulletDestroyed()
            {
                _gameLoop.RemoveUpdate(bullet);
                _gameLoop.RemoveFixedUpdate(bullet);
                bullet.Destroyed -= OnBulletDestroyed;
            }

            _gameLoop.AddUpdate(bullet);
            _gameLoop.AddFixedUpdate(bullet);
            bullet.Destroyed += OnBulletDestroyed;
        }
    }
}