using System;

namespace Model.PlayerShip.Weapon
{
    public interface ILaserCooldown
    {
        float Cooldown { get; }
        event Action<float> CooldownChanged;
    }
}