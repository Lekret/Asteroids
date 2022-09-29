using Model.PlayerShip.Weapon;
using UnityEngine;

namespace View
{
    public class BulletView : MonoBehaviour
    {
        [SerializeField] private PositionView _positionView;
        
        private IBullet _bullet;
        
        public void Init(IBullet bullet)
        {
            _bullet = bullet;
            _positionView.Init(bullet);
            transform.rotation = _bullet.Rotation;
        }
        
        private void Update()
        {
            _bullet.Update(Time.deltaTime);
        }
    }
}