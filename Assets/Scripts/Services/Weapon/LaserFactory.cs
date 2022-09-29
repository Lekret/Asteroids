﻿using Model.PlayerShip.Weapon;
using UnityEngine;
using View;

namespace Services.Weapon
{
    public class LaserFactory : ILaserFactory
    {
        private readonly LaserView _prefab;

        public LaserFactory(LaserView prefab)
        {
            _prefab = prefab;
        }

        public Laser Create()
        {
            var view = Object.Instantiate(_prefab);
            var laser = new Laser();
            view.Init(laser);
            return laser;
        }
    }
}