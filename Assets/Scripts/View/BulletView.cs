using Model.PlayerShip.Weapon;
using UnityEngine;

namespace View
{
    public class BulletView : MonoBehaviour
    {
        [SerializeField] private PositionView _positionView;
        [SerializeField] private DestroyableView _destroyableView;
        [SerializeField] private HazardColliderView _hazardColliderView;
        
        private IBullet _bullet;
        
        public void Init(IBullet bullet)
        {
            _bullet = bullet;
            _positionView.Init(bullet);
            _destroyableView.Init(bullet);
            _hazardColliderView.Init(bullet);
            transform.rotation = _bullet.Rotation;
        }

        private void Update()
        {
            _bullet.Update(Time.deltaTime);
        }
        
        private void FixedUpdate()
        {
            _bullet.FixedUpdate(Time.deltaTime);
        }
    }
}