using Configuration;
using Model.Obstacles;
using Model.PlayerShip.Movement;
using Services;
using UnityEngine;

namespace ServicesImpl
{
    public class UfoFactory : IUfoFactory
    {
        private readonly IUfoConfiguration _configuration;
        private readonly IShipMovement _shipMovement;

        public UfoFactory(IUfoConfiguration configuration, IShipMovement shipMovement)
        {
            _configuration = configuration;
            _shipMovement = shipMovement;
        }

        public IUfo Create()
        {
            var view = Object.Instantiate(_configuration.UfoPrefab);
            var ufo = new Ufo(_shipMovement, _configuration.UfoSpeed);
            view.Init(ufo);
            return ufo;
        }
    }
}