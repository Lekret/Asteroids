using Model.Asteroids;

namespace Services.Asteroids
{
    public interface IAsteroidFactory
    {
        Asteroid Create();
    }
}