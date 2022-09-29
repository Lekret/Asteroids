using UnityEngine;

namespace Model.PlayerShip.Weapon
{
    public interface IBullet : IPositionable
    {
        Quaternion Rotation { get; }
        void Update(float deltaTime);
    }
}