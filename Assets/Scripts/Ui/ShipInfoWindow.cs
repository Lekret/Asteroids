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
            _ship.SecondaryWeapon.AmmoChanged += SetLaserAmmo;
            _ship.LaserCooldown.CooldownChanged += SetLaserCooldown;
            SetLaserCooldown(_ship.LaserCooldown.Cooldown);
            SetLaserAmmo();
        }

        private void OnDestroy()
        {
            _ship.Movement.PositionChanged -= SetPosition;
            _ship.Rotation.Changed -= SetRotationAngle;
            _ship.Movement.VelocityChanged -= SetInstantaneousVelocity;
            _ship.SecondaryWeapon.AmmoChanged -= SetLaserAmmo;
            _ship.LaserCooldown.CooldownChanged -= SetLaserCooldown;
        }

        private void SetPosition(Vector2 position)
        {
            _shipPosition.text = $"Position: X:{position.x:F2} Y:{position.y:F2}";
        }

        private void SetRotationAngle(Quaternion rotation)
        {
            _shipRotation.text = $"Rotation: {(int) rotation.z}";
        }

        private void SetInstantaneousVelocity(Vector2 velocity)
        {
            var instVel = velocity * Time.deltaTime;
            _instantaneousVelocity.text = $"Velocity: X:{instVel.x:F2} Y:{instVel.y:F2}";
        }

        private void SetLaserAmmo()
        {
            _laserAmmo.text = $"Laser ammo: {_ship.SecondaryWeapon.Ammo}";
        }

        private void SetLaserCooldown(float cooldown)
        {
            _laserCooldown.text = $"Laser cooldown: {(int) cooldown}";
        }
    }
}