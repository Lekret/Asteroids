﻿using Game.Ship;
using UnityEngine.InputSystem;

namespace Infrastructure
{
    public class InputRouter
    {
        private readonly PlayerControls _controls = new PlayerControls();
        private readonly ShipMovement _shipMovement;
        private readonly ShipRotation _shipRotation;

        public InputRouter(ShipMovement shipMovement, ShipRotation shipRotation)
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