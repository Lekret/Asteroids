using UnityEngine;

namespace Configuration
{
    [CreateAssetMenu(menuName = "Config/Game configuration", fileName = "GameConfiguration")]
    public class GameConfiguration : ScriptableObject
    {
        [SerializeField] private AnimationCurve _timeUntilSpawnCurve;

        public AnimationCurve TimeUntilSpawnCurve => _timeUntilSpawnCurve;
    }
}