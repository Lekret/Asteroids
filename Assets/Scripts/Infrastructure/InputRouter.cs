using Game.PlayerShip;
using UnityEngine.InputSystem;

namespace Infrastructure
{
    public class InputRouter
    {
        private readonly PlayerControls _controls = new PlayerControls();
        private readonly IShipMovement _shipMovement;
        private readonly IShipRotation _shipRotation;

        public InputRouter(IShipMovement shipMovement, IShipRotation shipRotation)
        {
            _shipMovement = shipMovement;
            _shipRotation = shipRotation;
        }

        public void PerformRouting()
        {
            _controls.Enable();
            _controls.ShipMap.Forward.performed += SetShipForwardInput;
            _controls.ShipMap.Forward.canceled += SetShipForwardInput;
            _controls.ShipMap.Rotation.performed += SetShipRotationInput;
            _controls.ShipMap.Rotation.canceled += SetShipRotationInput;
        }

        private void SetShipForwardInput(InputAction.CallbackContext ctx)
        { 
            _shipMovement.SetForwardInput(ctx.ReadValue<float>());
        }
        
        private void SetShipRotationInput(InputAction.CallbackContext ctx)
        { 
            _shipRotation.SetRotationInput(ctx.ReadValue<float>());
        }
    }
}