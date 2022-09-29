using Model.PlayerShip;
using UnityEngine;

namespace View
{
    public class ShipView : MonoBehaviour
    {
        [SerializeField] private PositionView _positionView;
        [SerializeField] private DestroyableView _destroyableView;
        [SerializeField] private HazardColliderView _hazardColliderView;
        
        private IShip _ship;

        public void Init(IShip ship)
        {
            _ship = ship;
            _positionView.Init(ship.Movement);
            _destroyableView.Init(ship);
            _hazardColliderView.Init(ship);
            _ship.Rotation.Changed += SetRotation;
        }

        private void OnDestroy()
        {
            _ship.Rotation.Changed -= SetRotation;
        }

        private void Update()
        {
            _ship.Update(Time.deltaTime);
        }
        
        private void FixedUpdate()
        {
            _ship.FixedUpdate(Time.deltaTime);
        }

        private void SetRotation(Quaternion rotation)
        {
            transform.rotation = rotation;
        }
    }
}