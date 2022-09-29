using Configuration;
using Factories.Impl;
using Model.GameMap;
using Model.Hazards;
using Model.Score;
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

        private IHazardSpawner _hazardSpawner;
        
        private void Start()
        {
            var randomizer = new Randomizer();
            var mapBounds = CalculateMapBounds();
            var scoreCounter = new ScoreCounter();
            var sceneLoader = new SceneLoader();
            var map = new Map(mapBounds, randomizer);
            var shipFactory = new ShipFactory(_shipConfiguration, map);
            var ship = shipFactory.Create();
            var asteroidFactory = new AsteroidFactory(_hazardConfiguration, map, randomizer);
            var ufoFactory = new UfoFactory(_hazardConfiguration, ship.Movement, map);
            var hazardSpawnerFactory = new HazardSpawnerFactory(
                asteroidFactory,
                ufoFactory, 
                randomizer, 
                _hazardConfiguration);
            _hazardSpawner = hazardSpawnerFactory.Create();
            var uiFactory = new UiFactory(_uiConfiguration, ship, scoreCounter, sceneLoader);
            new InputRouter(ship).Run();
            uiFactory.InitRoot();
            uiFactory.CreateShipInfo();
            ship.Destroyed += () =>
            {
                uiFactory.CreateGameOver();
            };
        }
        
        private void Update()
        {
            _hazardSpawner.Update(Time.deltaTime);
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
