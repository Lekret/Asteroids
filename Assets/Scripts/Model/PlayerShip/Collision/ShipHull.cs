using System;
using UnityEngine;

namespace Model.PlayerShip.Collision
{
    public class ShipHull : IShipHull
    {
        public event Action Destroyed;
        
        public void Destroy()
        {
            Debug.LogError("YOU DEAD LOL"); // TODO
        }
    }
}