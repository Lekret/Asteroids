﻿using Configuration;
using Model.Execution;
using Model.GameMap;
using Model.Hazards;
using Model.PlayerShip.Movement;
using UnityEngine;

namespace Factories.Impl
{
    public class UfoFactory : IUfoFactory
    {
        private readonly IUfoConfiguration _configuration;
        private readonly IShipMovement _shipMovement;
        private readonly IMap _map;
        private readonly IGameLoop _gameLoop;

        public UfoFactory(
            IUfoConfiguration configuration,
            IShipMovement shipMovement,
            IMap map,
            IGameLoop gameLoop)
        {
            _configuration = configuration;
            _shipMovement = shipMovement;
            _map = map;
            _gameLoop = gameLoop;
        }

        public IUfo Create()
        {
            var view = Object.Instantiate(_configuration.UfoPrefab);
            var ufo = new Ufo(_shipMovement, _map.RandomOuterPoint(), _configuration.UfoSpeed);
            view.Init(ufo);
            AddToGameLoop(ufo);
            return ufo;
        }
        
        private void AddToGameLoop(Ufo ufo)
        {
            void OnUfoDestroyed()
            {
                _gameLoop.RemoveFixedUpdate(ufo);
                ufo.Destroyed -= OnUfoDestroyed;
            }
            
            _gameLoop.AddFixedUpdate(ufo);
            ufo.Destroyed += OnUfoDestroyed;
        }
    }
}