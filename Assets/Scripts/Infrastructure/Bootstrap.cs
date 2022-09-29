using Configuration;
using Game.Factories;
using Game.Ship;
using UnityEngine;
using View.Factories;

namespace Infrastructure
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private ShipConfiguration _shipConfiguration;
        
        private Ship _ship;
        
        private void Start()
        {
            _ship = new ShipFactory(_shipConfiguration).Create();
            new InputRouter(_ship.Movement, _ship.Rotation).PerformRouting();
            new ShipViewFactory(_shipConfiguration.Prefab).Create(_ship.Movement, _ship.Rotation);
        }

        private void Update()
        {
            _ship.Update(Time.deltaTime);
        }
    }
}
