using Configuration;
using Model.PlayerShip;
using Services.PlayerShit;
using UnityEngine;
using Utils;

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
            new InputRouter(_ship).PerformRouting();
            new ShipViewFactory(_shipConfiguration.ShipPrefab).Create(_ship.Movement, _ship.Rotation);
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
