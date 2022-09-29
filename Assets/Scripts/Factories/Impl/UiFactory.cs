﻿using Configuration;
using Model.PlayerShip;
using Model.Score;
using Services.SceneLoader;
using UnityEngine;

namespace Factories.Impl
{
    public class UiFactory : IUiFactory
    {
        private readonly UiConfiguration _configuration;
        private readonly IScoreCounter _scoreCounter;
        private readonly ISceneLoader _sceneLoader;
        private readonly IShip _ship;
        private Transform _root;

        public UiFactory(
            UiConfiguration configuration,
            IShip ship,
            IScoreCounter scoreCounter,
            ISceneLoader sceneLoader)
        {
            _configuration = configuration;
            _ship = ship;
            _scoreCounter = scoreCounter;
            _sceneLoader = sceneLoader;
        }

        public void InitRoot()
        {
            _root = Object.Instantiate(_configuration.Root).transform;
        }

        public void CreateShipInfo()
        {
            var shipInfo = Object.Instantiate(_configuration.ShipInfoPrefab, _root);
            shipInfo.Init(_ship);
        }

        public void CreateGameOver()
        {
            var gameOver = Object.Instantiate(_configuration.GameOverPrefab, _root);
            gameOver.Init(_sceneLoader, _scoreCounter);
        }
    }
}