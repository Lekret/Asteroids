using Model.PlayerShip.Movement;
using Model.PlayerShip.Rotation;
using Model.PlayerShip.Weapon;

namespace Model.PlayerShip
{
    public interface IShip : IDestroyable
    {
        IShipMovement Movement { get; }
        IShipRotation Rotation { get; }
        IShipWeapon PrimaryWeapon { get; }
        IShipWeapon SecondaryWeapon { get; }
        void Update(float deltaTime);
        void Destroy();
    }
}