using Configuration;
using Model.Obstacles;
using Services;

namespace ServicesImpl
{
    public class ObstacleSpawnerFactory
    {
        private readonly IAsteroidFactory _asteroidFactory;
        private readonly IUfoFactory _ufoFactory;
        private readonly IRandomizer _randomizer;
        private readonly ISpawnConfiguration _spawnConfiguration;

        public ObstacleSpawnerFactory(
            IAsteroidFactory asteroidFactory,
            IUfoFactory ufoFactory, 
            IRandomizer randomizer, 
            ISpawnConfiguration spawnConfiguration)
        {
            _asteroidFactory = asteroidFactory;
            _ufoFactory = ufoFactory;
            _randomizer = randomizer;
            _spawnConfiguration = spawnConfiguration;
        }

        public ObstacleSpawner Create()
        {
            return new ObstacleSpawner(
                _asteroidFactory, 
                _ufoFactory, 
                _randomizer, 
                _spawnConfiguration.TimeUntilSpawnCurve);
        }
    }
}