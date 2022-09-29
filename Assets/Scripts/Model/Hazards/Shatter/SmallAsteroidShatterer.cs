namespace Model.Hazards.Shatter
{
    public class SmallAsteroidShatterer : IAsteroidShatterer
    {
        public void Shatter(IAsteroid asteroid)
        {
            asteroid.Destroy();
        }
    }
}