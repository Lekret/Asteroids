using System;

namespace Model.PlayerShip
{
    public class Lifetime : IDestroyable
    {
        private float _lifetime;
        private bool _destroyed;

        public Lifetime(float lifetime)
        {
            _lifetime = lifetime;
        }

        public void Update(float deltaTime)
        {
            if (_destroyed)
                return;
            
            _lifetime -= deltaTime;
            if (_lifetime <= 0)
            {
                Destroyed?.Invoke();
                _destroyed = true;
            }
        }

        public event Action Destroyed;
    }
}