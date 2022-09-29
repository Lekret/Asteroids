using Model.PlayerShip;
using UnityEngine;

namespace View
{
    public class ShipView : MonoBehaviour
    {
        [SerializeField] private PositionView _positionView;
        
        private IShip _ship;

        public void Init(IShip ship)
        {
            _ship = ship;
            _positionView.Init(ship.Movement);
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

        private void SetRotation(Quaternion rotation)
        {
            transform.rotation = rotation;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out ShipKillerView _))
            {
                _ship.Collider.OnCollision();
            }
        }
    }
}