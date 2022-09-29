using Model.PlayerShip;
using UnityEngine.InputSystem;

namespace Infrastructure
{
    public class InputRouter
    {
        private readonly PlayerControls _controls = new PlayerControls();
        private readonly IShip _ship;

        public InputRouter(IShip ship)
        {
            _ship = ship;
        }

        public void Run()
        {
            _ship.Destroyed += OnShipDestroyed;
            _controls.Enable();
            var shipMap = _controls.ShipMap;
            shipMap.Forward.performed += SetShipForwardInput;
            shipMap.Forward.canceled += SetShipForwardInput;
            shipMap.Rotation.performed += SetShipRotationInput;
            shipMap.Rotation.canceled += SetShipRotationInput;
            shipMap.PrimaryAttack.performed += UsePrimaryWeapon;
            shipMap.SecondaryAttack.performed += UseSecondaryWeapon;
        }

        private void OnShipDestroyed()
        {
            _ship.Destroyed -= OnShipDestroyed;
            _controls.Dispose();
        }

        private void UsePrimaryWeapon(InputAction.CallbackContext obj)
        {
            _ship.PrimaryWeapon.Use();
        }
        
        private void UseSecondaryWeapon(InputAction.CallbackContext obj)
        {
            _ship.SecondaryWeapon.Use();
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