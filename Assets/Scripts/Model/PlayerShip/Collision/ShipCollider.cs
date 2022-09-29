using UnityEngine;

namespace Model.PlayerShip.Collision
{
    public class ShipCollider : IShipCollider
    {
        public void OnCollision()
        {
            Debug.LogError("YOU DEAD LOL"); // TODO
        }
    }
}