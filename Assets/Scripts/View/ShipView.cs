using Game.PlayerShip;
using UnityEngine;

namespace View
{
    public class ShipView : MonoBehaviour
    {
        private IShipMovement _shipMovement;
        private IShipRotation _shipRotation;

        public void Init(IShipMovement shipMovement, IShipRotation shipRotation)
        {
            _shipMovement = shipMovement;
            _shipRotation = shipRotation;
            _shipMovement.PositionChanged += SetPosition;
            _shipRotation.RotationChanged += SetRotation;
        }

        private void OnDestroy()
        {
            _shipMovement.PositionChanged -= SetPosition;
            _shipRotation.RotationChanged -= SetRotation;
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