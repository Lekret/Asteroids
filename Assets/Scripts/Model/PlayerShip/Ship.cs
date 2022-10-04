using System;
using Model.Execution;
using Model.Hazards;
using Model.PlayerShip.Movement;
using Model.PlayerShip.Rotation;
using Model.PlayerShip.Teleport;
using Model.PlayerShip.Weapon;

namespace Model.PlayerShip
{
    public class Ship : IShip, IUpdatable, IFixedUpdatable
    {
        private bool _killed;

        public LaserCooldown LaserCooldown { get; set; }
        public ShipTeleport Teleport { get; set; }
        public ShipMovement Movement { get; set; }
        public ShipRotation Rotation { get; set; }
        public BulletWeapon PrimaryWeapon { get; set; }
        public LaserWeapon SecondaryWeapon { get; set; }

        ILaserCooldown IShip.LaserCooldown => LaserCooldown;
        IShipMovement IShip.Movement => Movement;
        IShipRotation IShip.Rotation => Rotation;
        IShipWeapon IShip.PrimaryWeapon => PrimaryWeapon;
        ILaserWeapon IShip.SecondaryWeapon => SecondaryWeapon;
        public event Action Killed;

        public void Update(float deltaTime)
        {
            LaserCooldown.Update(deltaTime);
        }

        public void FixedUpdate(float deltaTime)
        {
            Rotation.FixedUpdate(deltaTime);
            Movement.FixedUpdate(Rotation.Current, deltaTime);
            Teleport.FixedUpdate();
        }

        public void CollideWith(IAsteroid asteroid)
        {
            TryKill();
        }

        public void CollideWith(IUfo ufo)
        {
            TryKill();
        }

        private void TryKill()
        {
            if (_killed)
                return;
            _killed = true;
            Killed?.Invoke();
        }
    }
}