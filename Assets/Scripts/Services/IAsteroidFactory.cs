using Model.Asteroids;

namespace Services
{
    public interface IAsteroidFactory
    {
        Asteroid Create();
    }
}