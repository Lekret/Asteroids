using Model.PlayerShip.Collision;
using Model.PlayerShip.Movement;
using Model.PlayerShip.Rotation;
using Model.PlayerShip.Weapon;

namespace Model.PlayerShip
{
    public interface IShip
    {
        IShipMovement Movement { get; }
        IShipRotation Rotation { get; }
        IShipWeapon PrimaryWeapon { get; }
        IShipWeapon SecondaryWeapon { get; }
        IShipHull Hull { get; }
        void Update(float deltaTime);
    }
}