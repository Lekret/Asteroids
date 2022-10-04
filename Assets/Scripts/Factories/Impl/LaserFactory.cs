using Configuration;
using Model.Execution;
using Model.PlayerShip;
using Model.PlayerShip.Weapon;
using UnityEngine;

namespace Factories.Impl
{
    public class LaserFactory : ILaserFactory
    {
        private readonly ShipConfiguration _shipConfiguration;
        private readonly IShip _ship;
        private readonly IGameLoop _gameLoop;

        public LaserFactory(ShipConfiguration shipConfiguration, IShip ship, IGameLoop gameLoop)
        {
            _shipConfiguration = shipConfiguration;
            _ship = ship;
            _gameLoop = gameLoop;
        }

        public ILaser Create()
        {
            var view = Object.Instantiate(_shipConfiguration.LaserPrefab);
            var laser = new Laser(
                _ship.Movement.Position,
                _ship.Rotation.Current,
                _shipConfiguration.LaserLifetime);
            view.Init(laser);
            AddToGameLoop(laser);
            return null;
        }
        
        private void AddToGameLoop(Laser laser)
        {
            void OnLaserDestroyed()
            {
                _gameLoop.RemoveUpdate(laser);
                laser.Destroyed -= OnLaserDestroyed;
            }
            
            _gameLoop.AddUpdate(laser);
            laser.Destroyed += OnLaserDestroyed;
        }
    }
}