using Model.PlayerShip;
using UnityEngine;

namespace View
{
    public class ShipView : MonoBehaviour
    {
        private IShip _ship;

        public void Init(IShip ship)
        {
            _ship = ship;
            _ship.Movement.PositionChanged += SetPosition;
            _ship.Rotation.Changed += SetRotation;
        }

        private void OnDestroy()
        {
            _ship.Movement.PositionChanged -= SetPosition;
            _ship.Rotation.Changed -= SetRotation;
        }
        
        private void Update()
        {
            _ship.Update(Time.deltaTime);
        }

        private void SetPosition(Vector2 position)
        {
            transform.position = position;
        }

        private void SetRotation(float rotationZ)
        {
            transform.rotation = Quaternion.AngleAxis(rotationZ, Vector3.forward);
        }
    }
}