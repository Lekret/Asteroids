using Ui;
using UnityEngine;

namespace Configuration
{
    [CreateAssetMenu(menuName = "Config/Ui configuration", fileName = "UiConfiguration")]
    public class UiConfiguration : ScriptableObject
    {
        [SerializeField] private GameObject _root;
        [SerializeField] private GameOverWindow _gameOverPrefab;
        [SerializeField] private ShipInfoWindow _shipInfoPrefab;

        public GameObject Root => _root;
        public GameOverWindow GameOverPrefab => _gameOverPrefab;
        public ShipInfoWindow ShipInfoPrefab => _shipInfoPrefab;
    }
}