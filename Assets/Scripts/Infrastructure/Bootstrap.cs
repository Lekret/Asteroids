using Configuration;
using Factories.Impl;
using Model.Execution;
using Model.GameMap;
using Model.Score;
using Services.Pause;
using Services.Randomizer;
using Services.SceneLoader;
using UnityEngine;
using Utils;

namespace Infrastructure
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private ShipConfiguration _shipConfiguration;
        [SerializeField] private HazardConfiguration _hazardConfiguration;
        [SerializeField] private UiConfiguration _uiConfiguration;

        private GameLoop _gameLoop;
        
        private void Start()
        {
            _gameLoop = new GameLoop().AddDefaultExecutionOrder();
            var randomizer = new Randomizer();
            var pauseService = new PauseService();
            var scoreTracker = new ScoreTracker();
            var mapBounds = CalculateMapBounds();
            var sceneLoader = new SceneLoader();
            var map = new Map(mapBounds, randomizer);
            var shipFactory = new ShipFactory(_shipConfiguration, map, _gameLoop);
            var ship = shipFactory.Create();
            var asteroidFactory = new AsteroidFactory(_hazardConfiguration, map, randomizer, _gameLoop, scoreTracker);
            var ufoFactory = new UfoFactory(_hazardConfiguration, ship.Movement, map, _gameLoop, scoreTracker);
            var hazardSpawnerFactory = new HazardSpawnerFactory(
                asteroidFactory,
                ufoFactory,
                randomizer,
                _hazardConfiguration,
                _gameLoop);
            hazardSpawnerFactory.Create();
            var uiFactory = new UiFactory(_uiConfiguration, scoreTracker, sceneLoader, pauseService, ship);
            new InputRouter(ship).Run();
            uiFactory.InitRoot();
            uiFactory.CreateShipInfo();
            ship.Killed += () =>
            {
                uiFactory.CreateGameOver();
            };
        }

        private void Update()
        {
            _gameLoop.Update(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            _gameLoop.FixedUpdate(Time.deltaTime);
        }

        private Bounds CalculateMapBounds()
        {
            var mapBounds = _camera.CalculateBounds();
            var mapAdditionalSize = Vector3.one;
            mapBounds.size += mapAdditionalSize;
            return mapBounds;
        }
    }
}