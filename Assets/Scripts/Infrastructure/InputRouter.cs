using Game.PlayerShip;
using UnityEngine.InputSystem;

namespace Infrastructure
{
    public class InputRouter
    {
        private readonly PlayerControls _controls = new PlayerControls();
        private readonly Ship _ship;

        public InputRouter(Ship ship)
        {
            _ship = ship;
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
            _ship.Movement.SetForwardInput(ctx.ReadValue<float>());
        }
        
        private void SetShipRotationInput(InputAction.CallbackContext ctx)
        { 
            _ship.Rotation.SetRotationInput(ctx.ReadValue<float>());
        }
    }
}