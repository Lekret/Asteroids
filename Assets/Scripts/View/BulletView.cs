using Game.PlayerShip.Weapon;
using UnityEngine;

namespace View
{
    public class BulletView : MonoBehaviour
    {
        private Bullet _bullet;
        
        public void Init(Bullet bullet)
        {
            _bullet = bullet;
        }

        private void OnTriggerEnter(Collider other)
        {
            
        }
    }
}