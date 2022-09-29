using Configuration;
using Model.GameMap;
using ServicesImpl;
using UnityEngine;
using Utils;

namespace Infrastructure
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private ShipConfiguration _shipConfiguration;
        [SerializeField] private GameConfiguration _gameConfiguration;

        private GameLoop _gameLoop;
        
        private void Start()
        {
            var randomizer = new Randomizer();
            var mapBounds = CalculateMapBounds();
            var map = new Map(mapBounds, randomizer);
            var shipFactory = new ShipFactory(_shipConfiguration, map);
            var ship = shipFactory.Create();
            var asteroidFactory = new AsteroidFactory(_gameConfiguration, randomizer, map);
            var ufoFactory = new UfoFactory(_gameConfiguration, ship.Movement);
            var obstacleSpawnerFactory = new ObstacleSpawnerFactory(
                asteroidFactory,
                ufoFactory, 
                randomizer, 
                _gameConfiguration);
            var obstacleSpawner = obstacleSpawnerFactory.Create();
            new InputRouter(ship).Run();
            _gameLoop = new GameLoop(obstacleSpawner);
        }
        
        private void Update()
        {
            _gameLoop.Update(Time.deltaTime);
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
