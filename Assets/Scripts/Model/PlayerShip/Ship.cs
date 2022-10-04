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

        public ILaserCooldown LaserCooldown { get; set; }
        public IShipTeleport Teleport { get; set; }
        public IShipMovement Movement { get; set; }
        public IShipRotation Rotation { get; set; }
        public IShipWeapon PrimaryWeapon { get; set; }
        public ILaserWeapon SecondaryWeapon { get; set; }
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