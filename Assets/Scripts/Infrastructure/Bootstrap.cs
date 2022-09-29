using Configuration;
using Model.PlayerShip;
using Services.Impl;
using UnityEngine;
using Utils;

namespace Infrastructure
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private ShipConfiguration _shipConfiguration;
        
        private IShip _ship;
        
        private void Start()
        {
            var mapBounds = CalculateMapBounds();
            _ship = new ShipFactory(_shipConfiguration, mapBounds).Create();
            new InputRouter(_ship).PerformRouting();
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
