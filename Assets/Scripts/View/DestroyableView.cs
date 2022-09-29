using Model;
using UnityEngine;

namespace View
{
    public class DestroyableView : MonoBehaviour
    {
        private IDestroyable _destroyable;
        private bool _destroyed;

        public void Init(IDestroyable destroyable)
        {
            _destroyable = destroyable;
            _destroyable.Destroyed += DestroySelf;
        }

        private void OnDestroy()
        {
            _destroyable.Destroyed -= DestroySelf;
        }

        private void DestroySelf()
        {
            if (_destroyed)
                return;
            _destroyed = true;
            Destroy(gameObject);
        }
    }
}