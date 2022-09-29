namespace Game.Ship
{
    public class Ship
    {
        public Ship(ShipMovement movement, ShipRotation rotation)
        {
            Movement = movement;
            Rotation = rotation;
        }

        public ShipMovement Movement { get; }
        public ShipRotation Rotation { get; }

        public void Update(float deltaTime)
        {
            Rotation.Update(deltaTime);
            Movement.Update(Rotation.Current, deltaTime);
        }
    }
}