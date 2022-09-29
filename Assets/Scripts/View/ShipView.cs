using Model.PlayerShip;
using UnityEngine;

namespace View
{
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
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

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out ShipKillerView _))
            {
                _ship.Collider.OnCollision();
            }
        }
    }
}