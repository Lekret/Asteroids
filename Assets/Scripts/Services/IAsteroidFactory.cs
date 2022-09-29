using Model.Asteroids;

namespace Services
{
    public interface IAsteroidFactory
    {
        IAsteroid Create();
    }
}