using Model.PlayerShip.Weapon;
using UnityEngine;

namespace View
{
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class BulletView : MonoBehaviour
    {
        [SerializeField] private PositionView _positionView;
        [SerializeField] private DestroyableView _destroyableView;
        
        private IBullet _bullet;
        
        public void Init(IBullet bullet)
        {
            _bullet = bullet;
            _positionView.Init(bullet);
            _destroyableView.Init(bullet);
            transform.rotation = _bullet.Rotation;
        }
        
        private void Update()
        {
            _bullet.Update(Time.deltaTime);
        }
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out AsteroidView asteroidView))
            {
                _bullet.CollideWith(asteroidView.Asteroid);
            } 
            else if (col.TryGetComponent(out UfoView ufoView))
            {
                _bullet.CollideWith(ufoView.Ufo);
            }
        }
    }
}