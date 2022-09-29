using System;

namespace Model.PlayerShip.Weapon
{
    public class LaserCooldown : ILaserCooldown
    {
        private readonly ILaserWeapon _laserWeapon;
        private readonly float _cooldownTime;
        private float _cooldown;
        
        public LaserCooldown(ILaserWeapon laserWeapon, float cooldownTime)
        {
            _laserWeapon = laserWeapon;
            _cooldownTime = cooldownTime;
            _cooldown = _cooldownTime;
        }

        public float Cooldown => _cooldown;
        public event Action<float> CooldownChanged;

        public void Update(float deltaTime)
        {
            if (_laserWeapon.Ammo == _laserWeapon.MaxAmmo)
                return;
            
            _cooldown -= deltaTime;
            if (_cooldown <= 0)
            {
                _cooldown = _cooldownTime;
                _laserWeapon.AddAmmo();
            }
            CooldownChanged?.Invoke(_cooldown);
        }
    }
}