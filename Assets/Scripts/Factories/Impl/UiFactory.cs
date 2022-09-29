using Configuration;
using Model.PlayerShip;
using Model.Score;
using Services.Pause;
using Services.SceneLoader;
using UnityEngine;

namespace Factories.Impl
{
    public class UiFactory : IUiFactory
    {
        private readonly UiConfiguration _configuration;
        private readonly IScoreTracker _scoreTracker;
        private readonly ISceneLoader _sceneLoader;
        private readonly IPauseService _pauseService;
        private readonly IShip _ship;
        private Transform _root;

        public UiFactory(
            UiConfiguration configuration,
            IScoreTracker scoreTracker,
            ISceneLoader sceneLoader,
            IPauseService pauseService,
            IShip ship)
        {
            _configuration = configuration;
            _scoreTracker = scoreTracker;
            _sceneLoader = sceneLoader;
            _pauseService = pauseService;
            _ship = ship;
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
            gameOver.Init(_sceneLoader, _pauseService, _scoreTracker);
        }
    }
}