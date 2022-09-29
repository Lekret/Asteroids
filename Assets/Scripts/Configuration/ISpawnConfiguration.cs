using UnityEngine;

namespace Configuration
{
    public interface ISpawnConfiguration
    {
        AnimationCurve TimeUntilSpawnCurve { get; }
    }
}