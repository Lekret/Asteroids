namespace Game.PlayerShip
{
    public class Ship
    {
        public Ship(ShipMovement movement, ShipRotation rotation, ShipTeleport teleport)
        {
            Movement = movement;
            Rotation = rotation;
            Teleport = teleport;
        }

        public ShipMovement Movement { get; }
        public ShipRotation Rotation { get; }
        public ShipTeleport Teleport { get; }

        public void Update(float deltaTime)
        {
            Rotation.Update(deltaTime);
            Movement.Update(Rotation.Current, deltaTime);
            Teleport.Update();
        }
    }
}