using Model;
using UnityEngine;

namespace View
{
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class HazardColliderView : MonoBehaviour
    {
        private IHazardCollider _hazardCollider;

        public void Init(IHazardCollider hazardCollider)
        {
            _hazardCollider = hazardCollider;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out AsteroidView asteroidView))
            {
                _hazardCollider.CollideWith(asteroidView.Asteroid);
            }
            else if (col.TryGetComponent(out UfoView ufoView))
            {
                _hazardCollider.CollideWith(ufoView.Ufo);
            }
        }
    }
}