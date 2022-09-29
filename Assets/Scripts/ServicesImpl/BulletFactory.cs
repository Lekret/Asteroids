﻿using Model.PlayerShip.Weapon;
using Services;
using UnityEngine;
using View;

namespace ServicesImpl
{
    public class BulletFactory : IBulletFactory
    {
        private readonly BulletView _prefab;

        public BulletFactory(BulletView prefab)
        {
            _prefab = prefab;
        }

        public IBullet Create()
        {
            var view = Object.Instantiate(_prefab);
            var bullet = new Bullet();
            view.Init(bullet);
            return bullet;
        }
    }
}