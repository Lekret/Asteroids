using Model.PlayerShip.Movement;
using Model.PlayerShip.Rotation;
using Model.PlayerShip.Teleport;
using Model.PlayerShip.Weapon;

namespace Model.PlayerShip
{
    public class ShipFacade : IShip
    {
        public IShipTeleport Teleport { get; set; }
        public IShipMovement Movement { get; set; }
        public IShipRotation Rotation { get; set; }
        public IShipWeapon PrimaryWeapon { get; set; }
        public IShipWeapon SecondaryWeapon { get; set; }

        public void Update(float deltaTime)
        {
            Rotation.Update(deltaTime);
            Movement.Update(Rotation.Current, deltaTime);
            Teleport.Update();
        }
    }
}