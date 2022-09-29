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
            Rotation.Update(deltaTime);
            Movement.Update(Rotation.Current, deltaTime);
            Teleport.Update();
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