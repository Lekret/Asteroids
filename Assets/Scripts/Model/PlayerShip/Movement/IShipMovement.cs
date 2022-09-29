using UnityEngine;

namespace Model.PlayerShip.Movement
{
    public interface IShipMovement : IPositionable
    {
        new Vector2 Position { get; set; }
        void SetForwardInput(float forwardInput);
        void Update(Quaternion rotation, float deltaTime);
    }
}