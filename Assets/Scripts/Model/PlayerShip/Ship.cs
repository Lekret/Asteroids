using System;
using Model.Hazards;
using Model.PlayerShip.Movement;
using Model.PlayerShip.Rotation;
using Model.PlayerShip.Teleport;
using Model.PlayerShip.Weapon;

namespace Model.PlayerShip
{
    public class Ship : IShip
    {
        public ILaserCooldown LaserCooldown { get; set; }
        public IShipTeleport Teleport { get; set; }
        public IShipMovement Movement { get; set; }
        public IShipRotation Rotation { get; set; }
        public IShipWeapon PrimaryWeapon { get; set; }
        public IShipWeapon SecondaryWeapon { get; set; }
        public event Action Destroyed;

        public void Update(float deltaTime)
        {
            LaserCooldown.Update(deltaTime);
        }

        public void FixedUpdate(float deltaTime)
        {
            Rotation.Update(deltaTime);
            Movement.Update(Rotation.Current, deltaTime);
            Teleport.Update();
        }
        
        public void CollideWith(IAsteroid asteroid)
        {
            Destroyed?.Invoke();
        }

        public void CollideWith(IUfo ufo)
        {
            Destroyed?.Invoke();
        }
    }
}