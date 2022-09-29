using System;

namespace Model.PlayerShip.Weapon
{
    public interface ILaserCooldown
    {
        event Action<float> CooldownChanged;
        void Update(float deltaTime);
    }
}