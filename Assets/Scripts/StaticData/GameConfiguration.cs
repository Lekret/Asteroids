using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Game configuration", fileName = "GameConfiguration")]
    public class GameConfiguration : ScriptableObject
    {
        [SerializeField] private ShipConfiguration _shipConfiguration;

        public ShipConfiguration Ship => _shipConfiguration;
    }
}