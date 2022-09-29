using Model.PlayerShip.Movement;
using Model.PlayerShip.Rotation;
using Model.PlayerShip.Teleport;
using Model.PlayerShip.Weapon;

namespace Model.PlayerShip
{
    public class Ship
    {
        public Ship(
            IShipMovement movement, 
            IShipRotation rotation,
            IShipTeleport teleport,
            IShipWeapon primaryWeapon,
            IShipWeapon secondaryWeapon)
        {
            Movement = movement;
            Rotation = rotation;
            Teleport = teleport;
            PrimaryWeapon = primaryWeapon;
            SecondaryWeapon = secondaryWeapon;
        }

        public IShipMovement Movement { get; }
        public IShipRotation Rotation { get; }
        public IShipTeleport Teleport { get; }
        public IShipWeapon PrimaryWeapon { get; }
        public IShipWeapon SecondaryWeapon { get; }

        public void Update(float deltaTime)
        {
            Rotation.Update(deltaTime);
            Movement.Update(Rotation.Current, deltaTime);
            Teleport.Update();
        }
    }
}