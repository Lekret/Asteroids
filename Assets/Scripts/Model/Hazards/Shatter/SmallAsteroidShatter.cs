namespace Model.Hazards.Shatter
{
    public class SmallAsteroidShatter : IAsteroidShatter
    {
        public void Shatter(IAsteroid asteroid)
        {
            asteroid.Destroy();
        }
    }
}