using Configuration;
using Model.Hazards;
using Services;

namespace ServicesImpl
{
    public class HazardSpawnerFactory
    {
        private readonly IAsteroidFactory _asteroidFactory;
        private readonly IUfoFactory _ufoFactory;
        private readonly IRandomizer _randomizer;
        private readonly ISpawnConfiguration _spawnConfiguration;

        public HazardSpawnerFactory(
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

        public HazardSpawner Create()
        {
            return new HazardSpawner(
                _asteroidFactory, 
                _ufoFactory, 
                _randomizer, 
                _spawnConfiguration.TimeUntilSpawnCurve);
        }
    }
}