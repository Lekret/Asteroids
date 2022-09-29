using System;
using UnityEngine;

namespace Game
{
    public class Ship
    {
        private readonly float _acceleration;
        private readonly float _terminalAcceleration;
        private Vector2 _velocity;

        public event Action<Vector2> Changed;

        public void Update(int inputX, int inputY, float deltaTime)
        {
            _velocity += new Vector2(inputX, inputY) * _acceleration * deltaTime;
            _velocity = Vector2.ClampMagnitude(_velocity, _terminalAcceleration);
            Changed?.Invoke(_velocity);
        }
    }
}