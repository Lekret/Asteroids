using UnityEngine;
using View;

namespace Configuration
{
    [CreateAssetMenu(menuName = "Config/Ship configuration", fileName = "ShipConfiguration")]
    public class ShipConfiguration : ScriptableObject
    {
        [SerializeField] private float _acceleration;
        [SerializeField] private float _inertiaDrop;
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private float _bulletSpeed;
        [SerializeField] private float _bulletLifetime;
        [SerializeField] private float _laserCooldown;
        [SerializeField] private float _laserLifetime;
        [SerializeField] private float _laserMaxCount;
        [SerializeField] private ShipView _shipPrefab;
        [SerializeField] private BulletView _bulletPrefab;
        [SerializeField] private LaserView _laserPrefab;

        public float Acceleration => _acceleration;
        public float InertiaDrop => _inertiaDrop;
        public float MaxSpeed => _maxSpeed;
        public float RotationSpeed => _rotationSpeed;
        public float BulletSpeed => _bulletSpeed;
        public float BulletLifetime => _bulletLifetime;
        public float LaserCooldown => _laserCooldown;
        public float LaserLifetime => _laserLifetime;
        public float LaserMaxCount => _laserMaxCount;
        public ShipView ShipPrefab => _shipPrefab;
        public BulletView BulletPrefab => _bulletPrefab;
        public LaserView LaserPrefab => _laserPrefab;
    }
}