using Model.Obstacles;
using Services;
using UnityEngine;
using View;

namespace ServicesImpl
{
    public class UfoFactory : IUfoFactory
    {
        private readonly UfoView _prefab;

        public UfoFactory(UfoView prefab)
        {
            _prefab = prefab;
        }

        public IUfo Create()
        {
            var view = Object.Instantiate(_prefab);
            var ufo = new Ufo();
            view.Init(ufo);
            return ufo;
        }
    }
}