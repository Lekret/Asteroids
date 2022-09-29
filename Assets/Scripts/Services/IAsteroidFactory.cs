using Model.Obstacles;

namespace Services
{
    public interface IAsteroidFactory
    {
        IAsteroid Create(AsteroidSize size);
    }
}