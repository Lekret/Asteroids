using Configuration;
using Model.Execution;
using Model.Hazards;
using Services.Randomizer;

namespace Factories.Impl
{
    public class HazardSpawnerFactory
    {
        private readonly IAsteroidFactory _asteroidFactory;
        private readonly IUfoFactory _ufoFactory;
        private readonly IRandomizer _randomizer;
        private readonly ISpawnConfiguration _spawnConfiguration;
        private readonly IGameLoop _gameLoop;

        public HazardSpawnerFactory(
            IAsteroidFactory asteroidFactory,
            IUfoFactory ufoFactory,
            IRandomizer randomizer,
            ISpawnConfiguration spawnConfiguration,
            IGameLoop gameLoop)
        {
            _asteroidFactory = asteroidFactory;
            _ufoFactory = ufoFactory;
            _randomizer = randomizer;
            _spawnConfiguration = spawnConfiguration;
            _gameLoop = gameLoop;
        }

        public HazardSpawner Create()
        {
            var spawner = new HazardSpawner(
                _asteroidFactory,
                _ufoFactory,
                _randomizer,
                _spawnConfiguration.TimeUntilSpawnCurve);
            _gameLoop.AddUpdate(spawner);
            return spawner;
        }
    }
}