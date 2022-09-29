using Ui;
using UnityEngine;

namespace Configuration
{
    [CreateAssetMenu(menuName = "Config/Ui configuration", fileName = "UiConfiguration")]
    public class UiConfiguration : ScriptableObject
    {
        [SerializeField] private GameOverWindow _gameOverPrefab;
        [SerializeField] private GameInfoWindow _gameInfoPrefab;

        public GameOverWindow GameOverPrefab => _gameOverPrefab;
        public GameInfoWindow GameInfoPrefab => _gameInfoPrefab;
    }
}