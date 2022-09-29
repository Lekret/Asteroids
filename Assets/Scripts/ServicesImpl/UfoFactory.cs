using Configuration;
using Model.GameMap;
using Model.Hazards;
using Model.PlayerShip.Movement;
using Services;
using UnityEngine;

namespace ServicesImpl
{
    public class UfoFactory : IUfoFactory
    {
        private readonly IUfoConfiguration _configuration;
        private readonly IShipMovement _shipMovement;
        private readonly IMap _map;

        public UfoFactory(IUfoConfiguration configuration, IShipMovement shipMovement, IMap map)
        {
            _configuration = configuration;
            _shipMovement = shipMovement;
            _map = map;
        }

        public IUfo Create()
        {
            var view = Object.Instantiate(_configuration.UfoPrefab);
            var ufo = new Ufo(_shipMovement, _map.RandomOuterPoint(), _configuration.UfoSpeed);
            view.Init(ufo);
            return ufo;
        }
    }
}