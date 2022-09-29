using System;

namespace Model.PlayerShip.Weapon
{
    public class LaserCooldown : ILaserCooldown
    {
        private readonly LaserWeapon _laserWeapon;
        private readonly float _cooldownTime;
        private float _cooldown;
        
        public LaserCooldown(LaserWeapon laserWeapon, int cooldownTime)
        {
            _laserWeapon = laserWeapon;
            _cooldownTime = cooldownTime;
            _laserWeapon.Shot += OnShot;
        }

        public event Action<float> CooldownChanged;
        
        private void OnShot()
        {
            _cooldown = _cooldownTime;
        }

        public void Update(float deltaTime)
        {
            if (_cooldown <= 0) 
                return;
            _cooldown -= deltaTime;
            if (_cooldown <= 0)
            {
                _cooldown = 0;
                _laserWeapon.AddAmmo();
            }
            CooldownChanged?.Invoke(_cooldown);
        }
    }
}