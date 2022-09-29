using Model.PlayerShip.Movement;
using Model.PlayerShip.Rotation;
using Model.PlayerShip.Teleport;
using Model.PlayerShip.Weapon;

namespace Model.PlayerShip
{
    public class Ship : IShip
    {
        private readonly IShipTeleport _teleport;
        
        public Ship(
            IShipMovement movement, 
            IShipRotation rotation,
            IShipTeleport teleport,
            IShipWeapon primaryWeapon,
            IShipWeapon secondaryWeapon)
        {
            Movement = movement;
            Rotation = rotation;
            _teleport = teleport;
            PrimaryWeapon = primaryWeapon;
            SecondaryWeapon = secondaryWeapon;
        }

        public IShipMovement Movement { get; }
        public IShipRotation Rotation { get; }
        public IShipWeapon PrimaryWeapon { get; }
        public IShipWeapon SecondaryWeapon { get; }

        public void Update(float deltaTime)
        {
            Rotation.Update(deltaTime);
            Movement.Update(Rotation.Current, deltaTime);
            _teleport.Update();
        }
    }
}