using Model.PlayerShip.Movement;
using Model.PlayerShip.Rotation;
using Model.PlayerShip.Teleport;
using Model.PlayerShip.Weapon;

namespace Model.PlayerShip
{
    public interface IShip
    {
        IShipMovement Movement { get; }
        IShipRotation Rotation { get; }
        IShipTeleport Teleport { get; }
        IShipWeapon PrimaryWeapon { get; }
        IShipWeapon SecondaryWeapon { get; }
        void Update(float deltaTime);
    }
}