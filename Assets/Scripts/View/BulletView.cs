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
        }

        private void OnTriggerEnter(Collider other)
        {
            
        }
    }
}