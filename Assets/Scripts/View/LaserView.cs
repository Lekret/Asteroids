using Model.PlayerShip.Weapon;
using UnityEngine;

namespace View
{
    public class LaserView : MonoBehaviour
    {
        [SerializeField] private PositionView _positionView;
        [SerializeField] private DestroyableView _destroyableView;
        [SerializeField] private HazardColliderView _hazardColliderView;
        
        public void Init(ILaser laser)
        {
            
        }
    }
}