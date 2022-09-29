using Model.PlayerShip;
using TMPro;
using UnityEngine;

namespace Ui
{
    public class ShipInfoWindow : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _shipPosition;
        [SerializeField] private TextMeshProUGUI _shipRotation;
        [SerializeField] private TextMeshProUGUI _instantaneousVelocity;
        [SerializeField] private TextMeshProUGUI _laserAmmo;
        [SerializeField] private TextMeshProUGUI _laserCooldown;

        private IShip _ship;
        
        public void Init(IShip ship)
        {
            _ship = ship;
            _ship.Movement.PositionChanged += SetPosition;
            _ship.Rotation.Changed += SetRotationAngle;
            _ship.Movement.VelocityChanged += SetInstantaneousVelocity;
            _ship.SecondaryWeapon.Shot += SetLaserAmmo;
            _ship.LaserCooldown.CooldownChanged += SetLaserCooldown;
            SetLaserCooldown(_ship.LaserCooldown.Cooldown);
            SetLaserAmmo();
        }

        private void OnDestroy()
        {
            _ship.Movement.PositionChanged -= SetPosition;
            _ship.Rotation.Changed -= SetRotationAngle;
            _ship.Movement.VelocityChanged -= SetInstantaneousVelocity;
            _ship.SecondaryWeapon.Shot -= SetLaserAmmo;
            _ship.LaserCooldown.CooldownChanged -= SetLaserCooldown;
        }

        private void SetPosition(Vector2 position)
        {
            _shipPosition.text = $"X:{position.x} Y:{position.y}";
        }
        
        private void SetRotationAngle(Quaternion rotation)
        {
            _shipRotation.text = $"Rotation: {rotation.z}";
        }
        
        private void SetInstantaneousVelocity(Vector2 velocity)
        {
            _instantaneousVelocity.text = $"Velocity: {velocity * Time.deltaTime}";
        }
        
        private void SetLaserAmmo()
        {
            _laserAmmo.text = $"Laser ammo: {_ship.SecondaryWeapon.Ammo}";
        }

        private void SetLaserCooldown(float cooldown)
        {
            _laserCooldown.text = $"Laser cooldown: {cooldown}";
        }
    }
}