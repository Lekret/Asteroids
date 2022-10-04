using Model.PlayerShip;
using UnityEngine;

namespace View
{
    public class ShipView : MonoBehaviour
    {
        [SerializeField] private PositionView _positionView;
        [SerializeField] private HazardColliderView _hazardColliderView;

        private IShip _ship;

        public void Init(IShip ship)
        {
            _ship = ship;
            _positionView.Init(ship.Movement);
            _hazardColliderView.Init(ship);
            _ship.Rotation.Changed += SetRotation;
        }

        private void OnDestroy()
        {
            _ship.Rotation.Changed -= SetRotation;
        }

        private void SetRotation(Quaternion rotation)
        {
            transform.rotation = rotation;
        }
    }
}