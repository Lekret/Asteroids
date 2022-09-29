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
        [SerializeField] private ShipView _shipPrefab;
        [SerializeField] private BulletView _bulletPrefab;
        [SerializeField] private LaserView _laserPrefab;

        public float Acceleration => _acceleration;
        public float InertiaDrop => _inertiaDrop;
        public float MaxSpeed => _maxSpeed;
        public float RotationSpeed => _rotationSpeed;
        public ShipView ShipPrefab => _shipPrefab;
        public BulletView BulletPrefab => _bulletPrefab;
        public LaserView LaserPrefab => _laserPrefab;
    }
}