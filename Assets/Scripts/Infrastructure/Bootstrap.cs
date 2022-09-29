using Configuration;
using Game.Factories;
using Game.PlayerShip;
using UnityEngine;
using Utils;
using View.Factories;

namespace Infrastructure
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private ShipConfiguration _shipConfiguration;
        
        private Ship _ship;
        
        private void Start()
        {
            var mapBounds = CalculateMapBounds();
            _ship = new ShipFactory(_shipConfiguration, mapBounds).Create();
            new InputRouter(_ship.Movement, _ship.Rotation).PerformRouting();
            new ShipViewFactory(_shipConfiguration.Prefab).Create(_ship.Movement, _ship.Rotation);
        }

        private Bounds CalculateMapBounds()
        {
            var mapBounds = _camera.CalculateBounds();
            var mapAdditionalSize = Vector3.one;
            mapBounds.size += mapAdditionalSize;
            return mapBounds;
        }

        private void Update()
        {
            _ship.Update(Time.deltaTime);
        }
    }
}
