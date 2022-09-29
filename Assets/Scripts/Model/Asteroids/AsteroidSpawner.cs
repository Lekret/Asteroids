using Services;

namespace Model.Asteroids
{
    public class AsteroidSpawner
    {
        private readonly IAsteroidFactory _asteroidFactory;

        public AsteroidSpawner(IAsteroidFactory asteroidFactory)
        {
            _asteroidFactory = asteroidFactory;
        }
    }
}