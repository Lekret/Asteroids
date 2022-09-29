using Model.Hazards;

namespace Services
{
    public interface IAsteroidFactory
    {
        IAsteroid Create(AsteroidSize size);
    }
}