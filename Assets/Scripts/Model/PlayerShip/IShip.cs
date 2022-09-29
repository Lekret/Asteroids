using Model.PlayerShip.Movement;
using Model.PlayerShip.Rotation;
using Model.PlayerShip.Weapon;

namespace Model.PlayerShip
{
    public interface IShip : IDestroyable, IHazardCollider
    {
        IShipMovement Movement { get; }
        IShipRotation Rotation { get; }
        IShipWeapon PrimaryWeapon { get; }
        IShipWeapon SecondaryWeapon { get; }
        void Update(float deltaTime);
        void FixedUpdate(float deltaTime);
    }
}