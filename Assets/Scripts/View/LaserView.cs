using Model.PlayerShip.Weapon;
using UnityEngine;

namespace View
{
    public class LaserView : MonoBehaviour
    {
        [SerializeField] private DestroyableView _destroyableView;
        [SerializeField] private HazardColliderView _hazardColliderView;

        private ILaser _laser;
        
        public void Init(ILaser laser)
        {
            _laser = laser;
            _destroyableView.Init(laser);
            _hazardColliderView.Init(laser);
            transform.position = laser.Position;
            transform.rotation = laser.Rotation;
        }

        private void Update()
        {
            _laser.Update(Time.deltaTime);
        }
    }
}