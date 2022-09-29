using Model.Hazards;
using UnityEngine;

namespace Model.PlayerShip.Weapon
{
    public interface IBullet : IPositionable, IDestroyable
    {
        Quaternion Rotation { get; }
        void Update(float deltaTime);
        void FixedUpdate(float deltaTime);
        void CollideWith(IAsteroid asteroid);
        void CollideWith(IUfo ufo);
    }
}