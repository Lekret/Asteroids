using UnityEngine;

namespace Model.PlayerShip.Weapon
{
    public interface IBullet : IPositionable, IDestroyable
    {
        Quaternion Rotation { get; }
        void Update(float deltaTime);
    }
}