using Factories;

namespace Model.Hazards.Shatter
{
    public class BigAsteroidShatterer : IAsteroidShatterer
    {
        private readonly IAsteroidFactory _asteroidFactory;

        public BigAsteroidShatterer(IAsteroidFactory asteroidFactory)
        {
            _asteroidFactory = asteroidFactory;
        }

        public void Shatter(IAsteroid asteroid)
        {
            for (var i = 0; i < 3; i++)
            {
                _asteroidFactory.CreateSmall(asteroid.Position);
            }
            asteroid.Destroy();
        }
    }
}