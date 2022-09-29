namespace Model.Obstacles
{
    public interface IAsteroid : IPositionable
    {
        void Update(float deltaTime);
    }
}