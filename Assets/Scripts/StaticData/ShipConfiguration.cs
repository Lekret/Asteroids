using UnityEngine;
using View;

namespace StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Ship configuration", fileName = "ShipConfiguration")]
    public class ShipConfiguration : ScriptableObject
    {
        [SerializeField] private float _acceleration;
        [SerializeField] private float _terminalAcceleration;
        [SerializeField] private ShipView _prefab;

        public float Acceleration => _acceleration;
        public float TerminalSpeed => _terminalAcceleration;
        public ShipView Prefab => _prefab;
    }
}