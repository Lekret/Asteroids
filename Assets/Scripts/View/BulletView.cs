using Model.PlayerShip.Weapon;
using UnityEngine;

namespace View
{
    public class BulletView : MonoBehaviour
    {
        private IBullet _bullet;
        
        public void Init(IBullet bullet)
        {
            _bullet = bullet;
            _bullet.PositionChanged += SetPosition;
            SetPosition(_bullet.Position);
            transform.rotation = _bullet.Rotation;
        }

        private void OnDestroy()
        {
            _bullet.PositionChanged -= SetPosition;
        }
        
        private void Update()
        {
            _bullet.Update(Time.deltaTime);
        }

        private void SetPosition(Vector2 position)
        {
            transform.position = position;
        }
    }
}