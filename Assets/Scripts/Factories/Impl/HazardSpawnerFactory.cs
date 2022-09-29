using Configuration;
using Model.Hazards;
using Model.Score;
using Services.Randomizer;

namespace Factories.Impl
{
    public class HazardSpawnerFactory
    {
        private readonly IAsteroidFactory _asteroidFactory;
        private readonly IUfoFactory _ufoFactory;
        private readonly IRandomizer _randomizer;
        private readonly ISpawnConfiguration _spawnConfiguration;
        private readonly IScoreTracker _scoreTracker;

        public HazardSpawnerFactory(
            IAsteroidFactory asteroidFactory,
            IUfoFactory ufoFactory, 
            IRandomizer randomizer, 
            ISpawnConfiguration spawnConfiguration, 
            IScoreTracker scoreTracker)
        {
            _asteroidFactory = asteroidFactory;
            _ufoFactory = ufoFactory;
            _randomizer = randomizer;
            _spawnConfiguration = spawnConfiguration;
            _scoreTracker = scoreTracker;
        }

        public HazardSpawner Create()
        {
            return new HazardSpawner(
                _asteroidFactory, 
                _ufoFactory, 
                _randomizer,
                _scoreTracker, 
                _spawnConfiguration.TimeUntilSpawnCurve);
        }
    }
}